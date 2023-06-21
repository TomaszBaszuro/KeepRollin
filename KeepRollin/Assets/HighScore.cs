using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        UpdateHighScoreText();
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = (((Mathf.Floor(PlayerPrefs.GetFloat("HighScore", 0) / 60f)) % 60).ToString("00")) + ":"
            + (Mathf.Floor(PlayerPrefs.GetFloat("HighScore", 0) % 60f).ToString("00")) + ":" + ((Mathf.Floor(PlayerPrefs.GetFloat("HighScore", 0) * 1000f) % 60).ToString("00"));
    }
}
