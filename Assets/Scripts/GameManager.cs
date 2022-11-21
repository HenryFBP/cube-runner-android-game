using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;

    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;


    IEnumerator SpawnObstacles()
    {
        while(true){
            float waitTime = Random.Range(0.5f, 2f);

            //wait a bit
            yield return new WaitForSeconds(waitTime);

            //spawn a new obstacle
            Vector3 spawnPos = spawnPoint.position;

            int shouldMoveUp = Random.Range(0, 2);

            if(shouldMoveUp > 0)
            {
                //move it by 1 or don't
                spawnPos.y += 1.5f;
            }

            //create the obstacle
            GameObject newObstacle = Instantiate(
                obstacle, 
                spawnPos, 
                Quaternion.identity);
            newObstacle.SetActive(true);
        }
    }


    void ScoreUp()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);

        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp", 2f, 1f);
    }

/*    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }
*/
    // Update is called once per frame
    void Update()
    {
        
    }
}
