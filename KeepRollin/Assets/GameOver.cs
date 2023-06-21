using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI finalTime;

    public void Setup(float time)
    {
        gameObject.SetActive(true);
        finalTime.text = (((Mathf.Floor(time / 60f)) % 60).ToString("00")) + ":"
            + (Mathf.Floor(time % 60f).ToString("00")) + ":" + ((Mathf.Floor(time * 1000f) % 60).ToString("00"));
    }

    public void OkButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
