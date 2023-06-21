using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;

    public GameObject obstacleUpper;
    public Transform spawnPointUpper;

    public GameObject obstacleFlying;
    public Transform spawnPointFlying;
    public Transform spawnPointFlyingUpper;

    public TextMeshProUGUI timerText;
    float currentTime = 0;

    public GameOver GameOverScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = (((Mathf.Floor(currentTime / 60f)) % 60).ToString("00")) + ":"
            + (Mathf.Floor(currentTime % 60f).ToString("00")) + ":" + ((Mathf.Floor(currentTime * 1000f) % 60).ToString("00"));
        if (Time.timeScale == 0 && currentTime > 0)
        {
            CheckHighScore();
            GameOver();
        }
    }

    IEnumerator SpwnObstacles()
    {
        while (true)
        {
            
            float waitTime = Random.Range(0.5f, 3f);
            
            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    IEnumerator SpwnObstaclesUpper()
    {
        while (true)
        {

            float waitTime = Random.Range(0.5f, 3f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacleUpper, spawnPointUpper.position, Quaternion.identity);
        }
    }

    IEnumerator SpwnObstaclesFlying()
    {
        while (true)
        {
            float drawSpawPoint = Random.Range(0f, 2f);

            yield return new WaitForSeconds(Random.Range(3f, 10f));

            if (drawSpawPoint > 1)
                Instantiate(obstacleFlying, spawnPointFlying.position, Quaternion.identity);
            else if (drawSpawPoint < 1)
                Instantiate(obstacleFlying, spawnPointFlyingUpper.position, Quaternion.identity);
        }
    }

    void CheckHighScore()
    {
        if(currentTime > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", currentTime);
        }
    }

    public void GameStart()
    {
        StartCoroutine(SpwnObstacles());
        StartCoroutine(SpwnObstaclesUpper());
        StartCoroutine(SpwnObstaclesFlying());
    }

   public void GameOver()
    {
        GameOverScreen.Setup(currentTime);
    }
}
