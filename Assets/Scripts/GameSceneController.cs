using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    private WebServerController webServerController;

    // Start is called before the first frame update
    void Start()
    {
        webServerController = FindObjectOfType<WebServerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
