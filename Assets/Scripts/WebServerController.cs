using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Net;
using System.Threading;

public class WebServerController : MonoBehaviour
{
    private HttpListener listener;
    private Thread listenerThread;

    // Start is called before the first frame update
    void Start()
    {
        if (!HttpListener.IsSupported)
        {
            Debug.Log("HttpListener not supported!");
            return;
        }

        // Create a listener.
        listener = new HttpListener();

        // Add a prefix
        listener.Prefixes.Add("http://*:8080/");

        listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
        listener.Start();

        listenerThread = new Thread(StartListener);
        listenerThread.Start();
        Debug.Log("Server Started");
    }

    private void Update()
    {
    }

    private void StartListener()
    {
        while (true)
        {
            var result = listener.BeginGetContext(ListenerCallback, listener);
            result.AsyncWaitHandle.WaitOne();
        }
    }

    private void ListenerCallback(IAsyncResult result)
    {
        var context = listener.EndGetContext(result);

        Debug.Log("Method: " + context.Request.HttpMethod);
        Debug.Log("LocalUrl: " + context.Request.Url.LocalPath);

        if (context.Request.QueryString.AllKeys.Length > 0)
            foreach (var key in context.Request.QueryString.AllKeys)
            {
                Debug.Log("Key: " + key + ", Value: " + context.Request.QueryString.GetValues(key)[0]);
            }

        if (context.Request.HttpMethod == "POST")
        {
            Thread.Sleep(1000);
            var data_text = new StreamReader(context.Request.InputStream,
                                context.Request.ContentEncoding).ReadToEnd();
            Debug.Log(data_text);
        }

        context.Response.Close();
    }
}