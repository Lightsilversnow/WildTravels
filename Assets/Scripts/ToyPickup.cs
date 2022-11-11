using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPickup : MonoBehaviour
{

    [SerializeField] int toyAmount;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<UIManager>().IncreaseCurrentToy();
            Destroy(gameObject);
        }
    }
}
