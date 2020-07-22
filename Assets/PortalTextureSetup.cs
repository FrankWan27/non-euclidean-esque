using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraObj;
    public Material cameraMat;

    void Start()
    {
        if (cameraObj.targetTexture != null)
            cameraObj.targetTexture.Release();

        cameraObj.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat.mainTexture = cameraObj.targetTexture;
    }
}
