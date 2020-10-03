using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    private static Cameras _instance;
    public static Cameras Instance => _instance;
    private void Awake()
    {
        _instance = this;

        DontDestroyOnLoad(this);        

    }
    public void ResetCameras()
    {
        Destroy(gameObject);
    }
}
