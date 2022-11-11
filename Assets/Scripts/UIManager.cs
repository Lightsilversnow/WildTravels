using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    InputManager inputManager;


    [SerializeField] int toyAmount = 0;
    [SerializeField] TextMeshProUGUI toyText;
    [SerializeField] TextMeshProUGUI toyMaxText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] int toyMax = 10;


    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }


    public int getCurrentToy()
    {
        return toyAmount;
    }

    public void IncreaseCurrentToy()
    {
        toyAmount++;
        Debug.Log(toyAmount);
        if (toyAmount >= toyMax)
        {
            GetComponent<EndMenu>().HandleCompleted();
        }
    }

    private void Update()
    {
        DisplayUI();
    }

    private void DisplayUI()
    {
        toyText.text = toyAmount.ToString();
        toyMaxText.text = toyMax.ToString();

        if (inputManager.timeInput)
        {
            timeText.text = "year 2300";
        }
        else
        {
            timeText.text = "year 2022";
        }
    }


}
