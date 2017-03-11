using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickupCollector : MonoBehaviour {

    public int score;
    public Text scoreText;
    public Text winText;

    void Start() {
        score = 0;
        SetScore();
        winText.text = "";
    }

    void OnTriggerEnter(Collider other) {
        var collectable = other.gameObject.GetComponent<Collectable>();
        if (collectable != null) {
            score += collectable.Collect();
            SetScore();
        }

            winText.text = "";
        if (score >= 1000 && score <= 1200) {
            winText.text = "You fucking did it.";
        }
        else if (score >= 2000 && score <= 2200) {
            winText.text = "You fucking did it again.";
        }
        else if (score >= 3000) {
            winText.text = "Do you feel better now?";
        }
    }

    void SetScore() {
        scoreText.text = score.ToString();
    }
}
