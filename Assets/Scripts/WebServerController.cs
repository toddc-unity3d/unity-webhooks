using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WebServerController : MonoBehaviour
{
    public string[] prefixes;
    private HttpListener listener;

    // Start is called before the first frame update
    void Start()
    {
        if (!HttpListener.IsSupported)
        {
            Debug.Log("HttpListener not supported!");
            return;
        }

        // URI prefixes are required,
        // for example "http://localhost:8080/spawnBox/".
        if (prefixes == null || prefixes.Length == 0)
            throw new ArgumentException("prefixes");

        // Create a listener.
        HttpListener listener = new HttpListener();

        // Add the prefixes.
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();

        Debug.Log("Server started...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
