using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    public int score;
    public Text scoreText;
    public Text winText;

    void Start() {
        score = 0;
        SetScoreText();
        winText.text = "";
    }

    public void AddPoints(int points) {
        score += points;
        SetScoreText();

        winText.text = "";
        if (score >= 1000 && score <= 1200) {
            winText.text = "Wow a thousand points.";
        }
        else if (score >= 2000 && score <= 2200) {
            winText.text = "You fucking did it.";
        }
        else if (score >= 3000) {
            winText.text = "Do you feel better now?";
            gameObject.GetComponent<Stickable>().isSticky = true;
        }
    }

    private void SetScoreText() {
        scoreText.text = score.ToString();
    }
}
