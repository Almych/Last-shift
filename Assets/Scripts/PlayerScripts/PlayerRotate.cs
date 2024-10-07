using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private float sensitivity = 150f;
    private float xRotation, yRotation;
    private float limitedYRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        LookAround();
    }

    private void LookAround ()
    {
        yRotation = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xRotation = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        limitedYRotation -= yRotation;
        limitedYRotation = Mathf.Clamp(limitedYRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(limitedYRotation, 0f, 0f);
        player.transform.Rotate(Vector3.up * xRotation);
    }
}
