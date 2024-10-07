using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BasicInteractable : MonoBehaviour
{
    public BasicAnimation.AnimationState state;
    [SerializeField] private AnimationClip open;
    [SerializeField] private AnimationClip close;
    private Animator anim;
    private InteractAnimationBehavior basicInteract;

    private void Start()
    {
         anim = GetComponent<Animator>();
         basicInteract = new BasicAnimation(anim, open, close, state);
    }

    public void Interact ()
    {
        basicInteract.Interact();
    }
}
