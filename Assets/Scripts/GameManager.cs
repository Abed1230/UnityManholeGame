using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject pedestrianTopPrefab;
    public GameObject pedestrianBottomPrefab;

    public Text scoreText;
    Collider2D playerCollider;

    int score = 0;

    float nextSpawn = 0f; //The time for the next item to spawn
    float spawnInterval = 10f; //The interval between spawned items
    float nextChange; //
    float changeInterval = 25f; //The interval between changing the interval between spanwed times

    float spawnDelay = 2f;
  
    int lowerSpawnCountLimit = 5;
    int higherSpawnCountLimit = 6;
    int lowerSpawnCount = 1;
    int higherSpawnCount = 1;

    int count = 1;

    // Use this for initialization
    void Start () {
        playerCollider = player.GetComponent<Collider2D>();
        scoreText.text = score.ToString();
        nextChange = changeInterval;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextSpawn) //If ready to spawn
        {
            StartCoroutine(SpawnPedestrian(Random.Range(lowerSpawnCount, higherSpawnCount)));
            nextSpawn += spawnInterval; //Set next spawn time

            if (Time.time >= nextChange) //If ready to change spawn interval
            {
                if (higherSpawnCount < higherSpawnCountLimit)
                {
                    higherSpawnCount++;
                    Debug.Log("curr max spawn: " + higherSpawnCount);
                }
                
                // Do every secondth time
                if (count % 2 == 0)
                {
                    if (lowerSpawnCount < lowerSpawnCountLimit)
                    {
                        lowerSpawnCount++;
                        Debug.Log("curr min spawn: " + lowerSpawnCount);
                    }
                }
                count++;
                nextChange += changeInterval; 
            }

        }
    }

    IEnumerator SpawnPedestrian(int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return new WaitForSeconds(spawnDelay);
            NewPedestrian();
        }
    }
    
    void NewPedestrian()
    {
        GameObject pref = Random.Range(0, 2) == 0 ? pedestrianTopPrefab : pedestrianBottomPrefab;
        GameObject ped = Instantiate(pref);
        ped.GetComponentInChildren<PedestrianController>().gameManager = this;
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void LoseOneLife()
    {

    }
 
}
