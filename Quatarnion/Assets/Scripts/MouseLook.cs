using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform Player;
    private float MouseX,MouseY;
    public float MouseSensitivity = 100f;
    public float Xrotation;
    
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X")*MouseSensitivity*Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y")*MouseSensitivity*Time.deltaTime;
        Xrotation -= MouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(Xrotation, 0, 0);
        Player.Rotate(Vector3.up * MouseX);
        

    }
}
