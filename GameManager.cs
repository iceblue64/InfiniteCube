/*****************************************************************//**
 * \file   GameManager.cs
 * \brief  Basic game manager functionality, including score tracking,
 *         obstacle spawning, and init logic.
 * 
 * \author Mike Doeren
 * \date   July 2023
 *********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // GUI

public class GameManager : MonoBehaviour
{
    // Variables
    public GameObject obstacle;
    public Transform spawnPoint;
    public GameObject player;
    public GameObject playButton;
    public TextMeshProUGUI scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ScoreIncrement()
    {
        ++score;
        scoreText.text = score.ToString();
    }

    IEnumerator SpawnObstacles()
    {
        // Note - an identity quaternion is a 3D rotation w/ no rotation representing an obj's original orientation

        while (true)
        {
            float waitTime = Random.Range(0.5f, 2.0f);

            // Wait...
            yield return new WaitForSeconds(waitTime);

            // ...and spawn
            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    // Init logic
    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreIncrement", 2.0f, 1.0f);
    }
}
