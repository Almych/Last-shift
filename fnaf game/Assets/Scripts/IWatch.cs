using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IWatchable
{

    public abstract void ChangeCameraForward();

    public abstract void ChangeCameraBackward();

    public abstract void PlayWatch();

    public abstract void StopWatch();
}
