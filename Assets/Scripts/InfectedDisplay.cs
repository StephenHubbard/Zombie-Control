using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfectedDisplay : MonoBehaviour
{

    public GameObject[] infected;
    TextMeshProUGUI infectedText;

    void Start()
    {
        infectedText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        updateText();
    }

    private void updateText()
    {
        infected = GameObject.FindGameObjectsWithTag("Infected");
        infectedText.text = ("Infected: " + infected.Length.ToString());
    }
}
