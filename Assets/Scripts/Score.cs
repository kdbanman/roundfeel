using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    public int score;
    public Text scoreText;
    public Text winText;

    private HashSet<string> shownMessages = new HashSet<string>();

    void Start() {
        score = 0;
        SetScoreText();
        winText.enabled = false;
    }

    public void AddPoints(int points) {
        score += points;
        SetScoreText();

        if (score >= 1000) {
            StartCoroutine(ShowMessage("Wow a thousand points.", 3.0f));
        }
        else if (score >= 2000) {
            StartCoroutine(ShowMessage("You fucking did it.", 3.0f));
        }
        else if (score >= 3000) {
            StartCoroutine(ShowMessage("Do you feel better now?", 3.0f));
            gameObject.GetComponent<Stickable>().isSticky = true;
        }
    }

    IEnumerator ShowMessage(string message, float seconds) {
        if (!shownMessages.Contains(message)) {
            shownMessages.Add(message);
            winText.text = message;
            winText.enabled = true;
            yield return new WaitForSeconds(seconds);
            winText.enabled = false;
        }
    }

    private void SetScoreText() {
        scoreText.text = score.ToString();
    }
}
