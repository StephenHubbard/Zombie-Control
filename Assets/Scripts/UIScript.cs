using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIScript : MonoBehaviour
{

    [SerializeField] GameObject maskImage;
    [SerializeField] GameObject nozzleImage;
    [SerializeField] TextMeshProUGUI waveCompleteText;
    [SerializeField] GameObject textWaveObject;
    InfectedDisplay infectedDisplay;
    NegativeDisplay negativeDisplay;
    PlayerMovement player;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        infectedDisplay = FindObjectOfType<InfectedDisplay>();
        negativeDisplay = FindObjectOfType<NegativeDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIcons();
        CheckWin();
    }

    private void ChangeIcons()
    {
        if (player.equipMask)
        {
            maskImage.GetComponent<Image>().color = new Color32(227, 231, 99, 255);
            nozzleImage.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        if (player.equipSpray)
        {
            nozzleImage.GetComponent<Image>().color = new Color32(227, 231, 99, 255);
            maskImage.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    private void CheckWin()
    {
        if (infectedDisplay.infected.Length == 0 && negativeDisplay.negative.Length > 1)
        {
            waveCompleteText.GetComponent<Animator>().SetBool("WaveComplete", true);
        }
    }

    public void StartWave()
    {
        textWaveObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void NextWave()
    {
        // get curren scene index and load next level. 
    }
}
