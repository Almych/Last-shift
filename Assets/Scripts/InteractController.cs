using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class ItemInteractController : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private TextMeshProUGUI nameItem;
    private RaycastHit hitObject;
    private bool isPicked = false;
    private float distance = 7f;
    private ItemInteractable currInteractObject;

    private const string takeText = "Press E to take";
    private const string dropText = "Press G to drop";
    private const string doorOpenText = "Press E to open";
    private const string doorCloseText = "Press E to close";
    private const string doorLockedText = "No energy";

    private void Update()
    {
        DetectInteractable();
    }

    private void DetectInteractable()
    {
        nameItem.gameObject.SetActive(false);
        if (Physics.Raycast(transform.position, transform.forward, out hitObject, distance))
        {

            if (hitObject.collider.GetComponent<ItemInteractable>() != null && !isPicked)
            {
                currInteractObject = hitObject.collider.GetComponent<ItemInteractable>();
                if (currInteractObject.itemType == IPickable.ItemType.Holdable)
                {
                    DisplayPressButton(takeText);
                    KeyCheck(KeyCode.E, () => { currInteractObject.Hold(hand); isPicked = true; });
                }
                else if (currInteractObject.itemType == IPickable.ItemType.Useable)
                {
                    DisplayPressButton(takeText);
                    KeyCheck(KeyCode.E, () => currInteractObject.Pick());
                }
            }
            else if (hitObject.collider.GetComponent<BasicInteractable>() != null)
            {
                var doorInteractable = hitObject.collider.GetComponent<BasicInteractable>();

                if (doorInteractable.state == BasicAnimation.AnimationState.Close)
                    DisplayPressButton(doorOpenText);
                else
                    DisplayPressButton(doorCloseText);
                KeyCheck(KeyCode.E, ()=> doorInteractable.Interact());

            }
            

            else if (hitObject.collider.GetComponent<CameraInteract>() != null)
            {
                var currInteractObject = hitObject.collider.GetComponent<CameraInteract>();
                DisplayPressButton(doorOpenText);
                KeyCheck(KeyCode.E, () => currInteractObject.PlayWatch());
            }

        }

        if (isPicked)
        {
            DisplayPressButton(dropText);
            KeyCheck(KeyCode.G, () => { currInteractObject.Drop(); isPicked = false; });
        }
    }



    private void DisplayPressButton(string keyName)
    {
        nameItem.text = keyName;
        nameItem.gameObject.SetActive(true);
    }

    private void KeyCheck(KeyCode key, Action interactAction)
    {
        if (Input.GetKeyDown(key))
        {
            interactAction();
        }
    }



}