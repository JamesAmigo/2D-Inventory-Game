using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This is a base class for all singletons in the game. Whenever you want to create script that will act as a singleton, you should inherit from this class.


//"SingletonBase<T>: MonoBehaviour" means: The "SingletonBase" class is a generic class that takes a type parameter T and inherits the Monobehaviour base class. 
//"where T : MonoBehaviour" means: T must be a MonoBehaviour or a class that inherits from MonoBehaviour.
public class SingletonBase<T>: MonoBehaviour where T : MonoBehaviour
{
    //This is a bool that let's you choose if you want to destroy the singleton object when you load a new scene.
    [SerializeField] private bool dontDestroyOnLoad = false;


    //This is a private static reference to the instance of the singleton object. T is the class that you made inherit from this class.
    private static T _instance;
    //This is a public static instance, which will be used to access the singleton object.
    public static T instance
    {
        //This is a getter for the instance. It will return the _instance
        get
        {  
            return GetInstance();
        }
    }
    //The reason we create a private and a public is to prevent other scripts from changing the value of the instance.


    public static T GetInstance()
    {
        T TinScene = FindObjectOfType<T>();

        if (TinScene != null)
            _instance = TinScene;
        if (_instance == null)
        {
            GameObject temp = new GameObject();
            temp.name = typeof(T).ToString();
            _instance = temp.AddComponent<T>();
        }

        return _instance;
    }


    

    //This is a virtual method that will be called when the singleton object is created.
    //The reason we make it virtual is so that we can override it in the classes that inherit from this class.
    //The Awake method is protected, which means that it can only be accessed by classes that inherit from this class.
    //Look at the Awake method in the InventoryManager class amd UIManager class for an example.
    protected virtual void Awake()
    {
        //If the instance doesn't exist, we will set it to this object.
        if (_instance == null)
        {
            _instance = this as T;
            //If we want the singleton object to persist between scenes, we will set it to DontDestroyOnLoad.
            if(dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        //If the instance already exists and it is not this object, we will destroy this object to prevent duplicates.
        else
        {
            Debug.LogError(typeof(T).ToString() + " class already existed");
            Destroy(this);
        }
    }


}
