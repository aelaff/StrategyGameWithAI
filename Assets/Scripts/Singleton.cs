using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:MonoBehaviour
{
    public static T instance;
    private void Awake()
    {
        RegisterSingelton();
    }

    protected void RegisterSingelton()
    {
        if (instance==null) {
            instance = this as T;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            
        }
    }
}
