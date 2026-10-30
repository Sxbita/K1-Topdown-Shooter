
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    public int killCount = 0;
    public TextMeshProUGUI killText;

    public int coinCount = 0;
    public TextMeshProUGUI coinText;

    public GameObject winPanel;          // drag WinPanel here

    private int coinsRemaining;
    private bool levelComplete;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        // Make sure the game isn't paused if we just reloaded
        Time.timeScale = 1f;

        coinsRemaining = FindObjectsOfType<Coin>().Length;
        levelComplete = false;

        if (winPanel != null) winPanel.SetActive(false);

        UpdateKillText();
        UpdateCoinText();
    }

    public void AddKill() {
        killCount++;
        UpdateKillText();
    }

    public void AddCoin(int amount) {
        coinCount += amount;
        coinsRemaining--;

        UpdateCoinText();

        if (coinsRemaining <= 0 && !levelComplete) {
            LevelComplete();
        }
    }

    private void LevelComplete() {
        levelComplete = true;
        Debug.Log("All coins collected — level complete!");

        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f;   // pause the game
    }

    public void Retry() {
        Time.timeScale = 1f;   // unpause BEFORE reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateKillText() {
        if (killText != null) killText.text = "Kills: " + killCount;
    }

    private void UpdateCoinText() {
        if (coinText != null) coinText.text = "Coins: " + coinCount;
    }
}