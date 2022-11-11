using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [HideInInspector]
    public DoorController door;
    [HideInInspector]
    public bool isTriggered = false;

    void OnTriggerEnter(Collider col) 
    {
         isTriggered = !isTriggered;
         if(isTriggered)
         {
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
         }
         else
         {
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;
         }
         door.StateChanged();
    }
}
