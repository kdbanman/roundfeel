using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    public int score;
    public Text scoreText;
    public Text winText;

    private Dictionary<int, string> messages;

    void Start() {
        score = 0;
        SetScoreText();
        winText.enabled = false;

        messages = new Dictionary<int, string>();
        messages.Add(1000, "Wow a thousand points.");
        messages.Add(2000, "You fucking did it.");
        messages.Add(3000, "Do you feel better now?");
    }

    public void AddPoints(int points) {
        score += points;
        SetScoreText();

        int lastThousandScorePassed = Mathf.FloorToInt((float)score / 1000f) * 1000;
        if (messages.ContainsKey(lastThousandScorePassed)) {
            StartCoroutine(ShowMessage(messages[lastThousandScorePassed], 3.0f));
            messages.Remove(lastThousandScorePassed);
        }

        if (score >= 3000) {
            gameObject.GetComponent<Stickable>().isSticky = true;
        }
    }

    IEnumerator ShowMessage(string message, float seconds) {
        winText.text = message;
        winText.enabled = true;
        yield return new WaitForSeconds(seconds);
        winText.enabled = false;
    }

    private void SetScoreText() {
        scoreText.text = score.ToString();
    }
}
