using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Door 
{
   enum DoorState
    {
        Locked,
        Open,
        Close
    };

    public abstract void Open();

    public abstract void Close();
    
    public abstract void Lock();
}
