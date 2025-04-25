using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int CurrentScore { get; set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI yourScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Image gameOverPanel;
    [SerializeField] private GameObject gameOverObject;
    [SerializeField] private float fadeTime = 2f;

    public float TimeTillGameOver = 1.5f;
    private int bestScore;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += FadeGame;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= FadeGame;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        scoreText.text = CurrentScore.ToString("0");
        bestScoreText.text = " " + bestScore.ToString("0");
    }

    public void IncreaseScore(int amount)
    {
        CurrentScore += amount;
        scoreText.text = CurrentScore.ToString("0");
        UpdateBestScore();
    }

    public void GameOver()
    {
        StartCoroutine(ResetGame());
    }

    private IEnumerator ResetGame()
    {
        gameOverPanel.gameObject.SetActive(true);
        yourScoreText.text = " " + CurrentScore.ToString("0");

        Color startColor = gameOverPanel.color;
        startColor.a = 0f;
        gameOverPanel.color = startColor;

        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(0f, 1f, (elapsedTime / fadeTime));
            startColor.a = newAlpha;
            gameOverPanel.color = startColor;

            yield return null;
        }
        gameOverObject.SetActive(true);

        yield return new WaitForSeconds(TimeTillGameOver);

    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(FadeGameIn());
    }

    private void FadeGame(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeGameIn());
    }

    private IEnumerator FadeGameIn()
    {
        gameOverPanel.gameObject.SetActive(true);
        Color startColor = gameOverPanel.color;
        startColor.a = 1f;
        gameOverPanel.color = startColor;

        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;

            float newAlpha = Mathf.Lerp(1f, 0f, (elapsedTime / fadeTime));
            startColor.a = newAlpha;
            gameOverPanel.color = startColor;

            yield return null;
        }

        gameOverPanel.gameObject.SetActive(false);
    }

    private void UpdateBestScore()
    {
        if (CurrentScore > bestScore)
        {
            bestScore = CurrentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
            bestScoreText.text = " " + bestScore.ToString("0");
        }
    }
}
