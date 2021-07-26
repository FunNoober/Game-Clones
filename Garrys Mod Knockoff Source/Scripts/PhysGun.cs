using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysGun : MonoBehaviour
{
    public Transform mainCam;
    private GameObject selectedObject;
    private bool hasObject;
    public LayerMask mask;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UsePhysGun();
        }

        if(Input.GetMouseButtonUp(0))
        {
            LetGoOfObject();
        }

        if(Input.GetMouseButtonDown(1))
        {
            LaunchObject();
        }
    }

    public void UsePhysGun()
    {
        RaycastHit hit;
        if(Physics.Raycast(mainCam.transform.position, mainCam.TransformDirection(Vector3.forward), out hit, 150f, mask))
        {
            selectedObject = hit.collider.gameObject;
            print(hit.collider.name);
            if(selectedObject != null && selectedObject.GetComponent<Rigidbody>())
            {
                selectedObject.transform.parent = mainCam;
                Rigidbody rb = selectedObject.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    rb.useGravity = false;
                    rb.constraints = RigidbodyConstraints.FreezePosition;
                    hasObject = true;
                }
            }
        }
    }

    public void LetGoOfObject()
    {
        Rigidbody rigidbody;
        if(selectedObject != null)
        {
            rigidbody = selectedObject.GetComponent<Rigidbody>();

            if(rigidbody != null)
            {
                rigidbody.useGravity = true;
                rigidbody.constraints = RigidbodyConstraints.None;
                rigidbody.transform.parent = null;
                hasObject = false;
            }
        }   
        

    }

    public void LaunchObject()
    {
        RaycastHit hit;
        if(Physics.Raycast(mainCam.position, mainCam.TransformDirection(Vector3.forward), out hit, 50f, mask))
        {
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddForce(mainCam.TransformDirection(Vector3.forward) * 15, ForceMode.Impulse);
            }
        }
    }
}
