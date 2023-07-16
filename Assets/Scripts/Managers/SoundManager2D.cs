using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager2D : SingletonBase<SoundManager2D>
{
    private AudioSource bgmSource;
    private AudioSource sfxSource;
    [SerializeField] private AudioClip[] bgmClips;
    [SerializeField] private AudioClip[] sfxClips;

    private float bgmStoredPauseTime;

    //Here we override the Awake method from the SingletonBase class.
    protected override void Awake()
    {
        //However, we still want to call the Awake method from the SingletonBase class, so we use the "base" keyword.
        base.Awake();
    }

    void Start()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        sfxSource.loop = false;
        bgmSource.playOnAwake = false;
        sfxSource.playOnAwake = false;
        PlayBGM("BGM_Shopping");
    }

    public void PlayBGM(string bgmName)
    {
        bgmStoredPauseTime = bgmSource.time;
        for(int i = 0; i < bgmClips.Length; i++)
        {
            if(bgmClips[i].name == bgmName)
            {
                StartCoroutine(FadeOutBGM(0.5f, bgmClips[i]));
                return;
            }
        }
    }

    public void PlaySFX(string sfxName)
    {
        for(int i = 0; i < sfxClips.Length; i++)
        {
            if(sfxClips[i].name == sfxName)
            {
                sfxSource.PlayOneShot(sfxClips[i]);
                return;
            }
        }
    }

    IEnumerator FadeOutBGM(float sec, AudioClip newBGMClip)
    {
        float timer = 0;
        float startValume = bgmSource.volume;
        while(bgmSource.volume > 0)
        {
            timer += Time.deltaTime;
            bgmSource.volume = Mathf.Lerp(startValume, 0, timer/sec);
            yield return null;
        }

        timer = 0;
        bgmSource.Stop();
        bgmSource.clip = newBGMClip;
        bgmSource.time = bgmStoredPauseTime;
        bgmSource.Play();

        while(bgmSource.volume < 1)
        {
            timer += Time.deltaTime;
            bgmSource.volume = Mathf.Lerp(0, startValume, timer/sec);
            yield return null;
        }
    }

    
}
