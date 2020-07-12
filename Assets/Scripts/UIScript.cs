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
    [SerializeField] GameObject dimImage;
    [SerializeField] GameObject miniMap;
    InfectedDisplay infectedDisplay;
    NegativeDisplay negativeDisplay;
    PlayerMovement player;
    public GameObject startTimer;
    private float startTimerFloat = 6f;

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
        UndimWaveStart();
        StartTimerCountdown();
    }

    private void StartTimerCountdown()
    {
        startTimerFloat -= Time.deltaTime;
        startTimer.GetComponent<TextMeshProUGUI>().text = startTimerFloat.ToString();
        if (startTimerFloat < 0)
        {
            startTimer.SetActive(false);
            player.canMove = true;
        }
    }

    private void UndimWaveStart()
    {
        if (Time.timeScale == 1)
        {
            dimImage.SetActive(false);
        }
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
        miniMap.SetActive(true);
        startTimer.SetActive(true);
    }

    public void NextWave()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
