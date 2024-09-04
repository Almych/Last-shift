using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(Rigidbody))]
public class ItemInteractable : MonoBehaviour, IPickable, IDropable
{
    public IPickable.ItemType itemType;
    private Rigidbody rb;
    private Vector3 scale;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        scale = transform.localScale;
    }

    public void Hold (Transform parent)
    {
        transform.parent = parent;
        transform.position = parent.transform.position;
        transform.localScale = scale;
        rb.isKinematic = true;
    }

    public void Pick ()
    {
        gameObject.SetActive(false);

    }

    public void Drop ()
    {
        transform.parent = null;
        rb.AddForceAtPosition(Vector3.forward, transform.position, ForceMode.Acceleration);
        transform.localScale = scale;
        rb.isKinematic = false;
    }

   

    
}
