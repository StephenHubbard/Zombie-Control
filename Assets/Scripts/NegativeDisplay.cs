using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NegativeDisplay : MonoBehaviour
{

    public GameObject[] negative;
    TextMeshProUGUI negativeText;

    void Start()
    {
        negativeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        updateText();
    }

    private void updateText()
    {
        negative = GameObject.FindGameObjectsWithTag("Negative");
        negativeText.text = ("Negative: " + negative.Length.ToString());
    }
}
