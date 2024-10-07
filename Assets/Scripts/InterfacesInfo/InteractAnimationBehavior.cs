using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractAnimationBehavior
{
    public enum AnimationState
    {
        Close,
        Open
    };
    public abstract void Interact();
}
