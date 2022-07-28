using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject confirm;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] Slider slider;

    private int currentScore;
    private float hp;

    public static GamePlayController Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReStart()
    {
        Reset();
        SceneManager.LoadScene("SampleScene");
    }

    public void UpdateScore(int point)
    {
        currentScore += point;
        score.text = currentScore.ToString();
    }

    public void UpdateSlider(int dam)
    {
        hp -= dam;
        slider.value = hp;

        hpText.text = hp + "%";

        if (hp <= 0)
        { 
            GameOver();
        }
    }

    public void ShowConfirm()
    {
        confirm.SetActive(true);
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        confirm.SetActive(false);
        Time.timeScale = 1;
    }

    public void Reset()
    {
        SoundController.Instance.PlayAudio(SoundController.Instance.bg, 0.7f, true);
        Time.timeScale = 1;
        hp = 100;
        UpdateScore(0);
        UpdateSlider(0);
        gameOver.SetActive(false);
        confirm.SetActive(false);
    }
}
