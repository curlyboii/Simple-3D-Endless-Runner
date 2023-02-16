using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public Transform spawnPoint; // [osition for spawning obstacle
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

    IEnumerator SpawnObstacles()
    { 
        while (true) 
        {

            float waitTime = Random.Range(0.7f, 2f);

            yield return new WaitForSeconds(waitTime); // wait this waitTime ad after obstacles spawn

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);

        }
    
    }

    public void GameStart()
    {

        StartCoroutine("SpawnObstacles");
    
    }
}
