using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _ammoText;

    public Text _scoreText;

    public Slider _HealthBar;
    public Gradient HpBar_Gradient;
    public Image fill;

    public Text[] BulletCounter;
    public int playerScore = 0;
    private int currentScore;

    void Start()
    {
        currentScore = playerScore;    
    }

    private void Update()
    {
        GameOverScene();
    }

    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count;
    }

    public void SetMaxHealth(int HPcount)
    {
        _HealthBar.maxValue = HPcount;
        _HealthBar.value = HPcount;

        fill.color = HpBar_Gradient.Evaluate(1f);
    }

    public void SetHealth(int HPcount)
    {
        _HealthBar.value = HPcount;

        fill.color = HpBar_Gradient.Evaluate(_HealthBar.normalizedValue);
    }

    public void UpdateScore(int Scorecount)
    {
        currentScore += Scorecount;

        _scoreText.text = "" + currentScore;
    }

    void GameOverScene()
    {
        if (_HealthBar.value < 1)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
