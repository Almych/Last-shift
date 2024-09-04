using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorInteractable : MonoBehaviour, Door
{
    public Door.DoorState state;
    private Animator anim;
    [SerializeField] private AnimationClip open;
    [SerializeField] private AnimationClip close;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        anim?.Play(open.name);
        state = Door.DoorState.Open;
    }

    public void Close ()
    {
        anim?.Play(close.name);
        state = Door.DoorState.Close;
    }



    public void Lock ()
    {
        state = Door.DoorState.Locked;
    }
}
