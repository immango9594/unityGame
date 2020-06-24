using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class ItemList : MonoBehaviour
{
    public static ItemList instance {get { return instance; } private set { } }

    private ArrayList list = new ArrayList();
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        DirectoryInfo direction = new DirectoryInfo("Assets/Resources");
        FileInfo[] files = direction.GetFiles("*");
        foreach (FileInfo file in files) 
        {
            Debug.Log(file.Name + " " + file.Attributes);
            list.Add(file.DirectoryName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
