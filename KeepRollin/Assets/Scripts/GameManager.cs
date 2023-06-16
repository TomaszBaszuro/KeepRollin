using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;

    public GameObject obstacleUpper;
    public Transform spawnPointUpper;

    public GameObject obstacleFlying;
    public Transform spawnPointFlying;
    public Transform spawnPointFlyingUpper;

    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpwnObstacles()
    {
        while (true)
        {
            
            float waitTime = Random.Range(0.5f, 4f);
            
            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    IEnumerator SpwnObstaclesUpper()
    {
        while (true)
        {

            float waitTime = Random.Range(0.5f, 4f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacleUpper, spawnPointUpper.position, Quaternion.identity);
        }
    }

    IEnumerator SpwnObstaclesFlying()
    {
        while (true)
        {
            float drawSpawPoint = Random.Range(0f, 2f);

            yield return new WaitForSeconds(Random.Range(1f, 10f));

            if (drawSpawPoint > 1)
                Instantiate(obstacleFlying, spawnPointFlying.position, Quaternion.identity);
            else if (drawSpawPoint < 1)
                Instantiate(obstacleFlying, spawnPointFlyingUpper.position, Quaternion.identity);
        }
    }
    public void GameStart()
    {
        StartCoroutine(SpwnObstacles());
        StartCoroutine(SpwnObstaclesUpper());
        StartCoroutine(SpwnObstaclesFlying());
    }
}
