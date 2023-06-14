using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject ammo;
    public GameObject player;
    private float startDelay = 2;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void StartSpawning(float speed)
    {
        InvokeRepeating("SpawnEnemy", startDelay, 4 - ((speed * 2) / 10));
        InvokeRepeating("SpawnPowarUp", startDelay, 2);
    }

    public void SpawnEnemy()
    {
        if (gameManager.isGameActive == true)
        {
            Vector3 spawnPos = new Vector3(55, Random.Range(3, 16), 0);
            int obstacaleIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[obstacaleIndex], spawnPos, enemies[obstacaleIndex].transform.rotation);
        }
    }
    public void SpawnPowarUp()
    {
        if (gameManager.isGameActive == true)
        {
            Vector3 spawnPos = new Vector3(55, Random.Range(3, 16), 0);
            Instantiate(ammo, spawnPos, ammo.transform.rotation);
        }
    }
    public void SpawnPlayer()
    {
        Vector3 spawnPos = new Vector3(0, 8, 0);
        Instantiate(player, spawnPos, player.transform.rotation);
    }
}
