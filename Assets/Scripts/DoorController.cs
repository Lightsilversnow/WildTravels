using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    GameObject[] plates;

    bool isOpened = false;

    void Start() 
    {
        foreach (var plate in plates)
        {
            plate.GetComponent<DoorTrigger>().door = this;
        }
    }
    
    public void StateChanged()
    {
        var allTriggered = true;
        foreach (var plate in plates)
        {
            if(plate.GetComponent<DoorTrigger>().isTriggered == false)
            {
                allTriggered = false;
            }
        }
        isOpened = allTriggered;
        this.UpdateDoor();
    }

    private void UpdateDoor() {
        if(isOpened)
        {
            this.transform.rotation = Quaternion.Euler (0f, 0f, 0f);

        }
    }
}
