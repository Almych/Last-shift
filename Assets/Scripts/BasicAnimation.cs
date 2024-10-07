using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimation : InteractAnimationBehavior
{
    private Animator animator;
    private AnimationClip closeAnim, openAnim;
    public AnimationState state;

    

    public BasicAnimation (Animator animator, AnimationClip close, AnimationClip open, AnimationState state)
    {
        this.animator = animator;
        closeAnim = close;
        openAnim = open;
        this.state = state;
        Interact();
    }


    public override void Interact()
    {
        if (state == AnimationState.Open)
        {
            animator?.Play(closeAnim.name);
            state = AnimationState.Close;
        }
        else if (state == AnimationState.Close) 
        {
            animator?.Play(openAnim.name);
            state = AnimationState.Open;
        }
    }


   
}
