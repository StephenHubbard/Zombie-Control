using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MasksDisplay : MonoBehaviour
{

    public float masksAvailable;
    private PlayerMovement player;

    TextMeshProUGUI maskDisplayText;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        maskDisplayText = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        maskDisplayText.text = player.masksAvailable.ToString();
    }
}
