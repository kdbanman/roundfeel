using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    public int score;
    public Text scoreText;

    void Start() {
        score = 0;
        SetScoreText();
    }

    public void AddPoints(int points) {
        score += points;
        SetScoreText();

        if (score >= 3000) {
            gameObject.GetComponent<Stickable>().isSticky = true;
        }
    }

    private void SetScoreText() {
        scoreText.text = score.ToString();
    }
}
