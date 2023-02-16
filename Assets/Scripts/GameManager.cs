using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public Transform spawnPoint; // [osition for spawning obstacle
    int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
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

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    
    }

    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);


        StartCoroutine("SpawnObstacles");

        InvokeRepeating("ScoreUp", 2f, 1f);
    }
}
