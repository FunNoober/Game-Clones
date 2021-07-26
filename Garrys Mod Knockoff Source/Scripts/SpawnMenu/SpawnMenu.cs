using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenu : MonoBehaviour
{
    public bool isEnabled = false;
    public GameObject menu;
    public PlayerMovementRotation playerRotation;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(isEnabled == false)
            {
                menu.SetActive(true);
                isEnabled = true;
                playerRotation.mouseSensitivity = 0f;
                Cursor.lockState = CursorLockMode.None;
                return;
            }

            if(isEnabled == true)
            {
                menu.SetActive(false);
                isEnabled = false;
                playerRotation.mouseSensitivity = 500f;
                Cursor.lockState = CursorLockMode.Locked;
                return;
            }
        }
    }
}
