using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    bool gameStarted = false;

    public GameObject tapText;
    public GameObject bannerText;
    public TextMeshProUGUI scoreText;

    int score = 0;

    // Start os called before the first frame update
    void Start()
    {
        scoreText.gameObject.SetActive(false);
        Block.BlockDestroyed += IncrementScore; // Subscribe to the BlockDestroyed event
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();

            gameStarted = true;
            tapText.SetActive(false);
            bannerText.SetActive(false);
            scoreText.gameObject.SetActive(true);
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        
        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate( block, spawnPos, Quaternion.identity );

        // score++; 

        // scoreText.text = score.ToString();
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void OnDestroy()
    {
        Block.BlockDestroyed -= IncrementScore; // Unsubscribe from the BlockDestroyed event
    }
}
