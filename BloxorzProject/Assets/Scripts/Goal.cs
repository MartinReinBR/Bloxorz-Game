using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private UI ui;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>().points == ui.allCoins)
        {
            ui.SetGoalText("You Win! Returning to Menu", 5, true);
        }
        else
        {
            ui.SetGoalText("You need all the Coins to advance!", 3, false);
        }
    }

}
