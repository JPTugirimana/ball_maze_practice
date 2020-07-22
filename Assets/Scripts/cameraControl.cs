using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraControl : MonoBehaviour
{
    public Transform Player;
    float mouseX, mouseY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CamControl()
    {

        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -15, 60);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Player.rotation = Quaternion.Euler(mouseY, mouseX, 0);

        }
        else
        {
            Player.rotation = Quaternion.Euler(0,0, 0);

        }
    }
}
