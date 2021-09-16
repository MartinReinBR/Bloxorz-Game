using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI goalText;
    public int allCoins;

    private void Start()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Coin"); 
        allCoins = allObjects.Length;
        SetPointsText(0);
    }

    public void SetPointsText(int points)
    {
        pointsText.text = points.ToString() + " / " + allCoins.ToString();
    }

    public void SetGoalText(string message, float delay, bool isWin)
    {
        StartCoroutine(ShowMessage(message, delay, isWin));
    }

    IEnumerator ShowMessage(string message, float delay, bool isWin)
    {
        goalText.text = message;
        goalText.enabled = true;
        yield return new WaitForSeconds(delay);
        goalText.enabled = false;
        if (isWin)
        {
            SceneManager.LoadScene(0);
        }
            
    }
}
