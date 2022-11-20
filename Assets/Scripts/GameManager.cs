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

            yield return new WaitForSeconds(waitTime);
            GameObject newObstacle = Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
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
