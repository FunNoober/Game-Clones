using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    List<GameObject> objectsToRemove = new List<GameObject>();
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void CleanUpEveryThing()
    {
        GameObject[] entities = GameObject.FindGameObjectsWithTag("Object");
        foreach(GameObject gameObject in entities)
        {
            objectsToRemove.Add(gameObject);
        }

        foreach(GameObject gameObject1 in GameObject.FindGameObjectsWithTag("AI"))
        {
            objectsToRemove.Add(gameObject1);
        }

        foreach(GameObject objectToRemove in objectsToRemove)
        {
            Destroy(objectToRemove);
        }
    }
}
