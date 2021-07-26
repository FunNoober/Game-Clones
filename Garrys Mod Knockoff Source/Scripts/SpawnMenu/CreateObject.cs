using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public LayerMask mask;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void MakeObject(GameObject objectToMake)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100f, mask))
        {
            Instantiate(objectToMake, hit.point, Quaternion.identity);
        }
    }
}
