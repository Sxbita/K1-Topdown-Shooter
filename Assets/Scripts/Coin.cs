using UnityEngine;

public class Coin : MonoBehaviour {
    public int coinValue = 1;
    private bool collected;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collected) return;
        if (!collision.CompareTag("Player")) return;

        collected = true;

        if (LevelManager.instance != null)
            LevelManager.instance.AddCoin(coinValue);

        Destroy(gameObject);
    }
}