using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraInteract : MonoBehaviour, IWatchable
{
    [SerializeField] private RenderTexture [] cameraAmount;
    [SerializeField] private Image cameraUi;
    [SerializeField] private RawImage currCameraTexture;
    private int maxIndex = 0;
    private static int currIndex = 0;

    private void Start()
    {
        
        currCameraTexture.texture = cameraAmount[0];
        maxIndex = cameraAmount.Length -1;
        Debug.Log(maxIndex);
    }
    public void ChangeCameraForward()
    {
        ChangeTexture(() => currIndex += 1, () => currIndex = 0);
    }

    public void ChangeCameraBackward()
    {
        ChangeTexture(() => currIndex -= 1, () => currIndex =  maxIndex);
    }

    public void PlayWatch()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       cameraUi.gameObject.SetActive(true);
    }

    public void StopWatch()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraUi.gameObject.SetActive(false);
    }

    private void ChangeTexture (Action actionIfTrue, Action actionIfFalse)
    {
        if (currIndex <= maxIndex)
        {
            actionIfTrue();
            if (currIndex > maxIndex || currIndex < 0) actionIfFalse();
            currCameraTexture.texture = cameraAmount[currIndex];
        }
    }
}
