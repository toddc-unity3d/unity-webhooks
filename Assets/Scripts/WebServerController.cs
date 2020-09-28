using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WebServerController : MonoBehaviour
{
    HttpListener listener;

    // Start is called before the first frame update
    void Start()
    {
        if (!HttpListener.IsSupported)
        {
            Debug.Log("HttpListener not supported!");
            return;
        }

        HttpListener listener = new HttpListener();


        Debug.Log("Server started...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
