using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints; //cria um vetor para os spawns de inimigos
    [SerializeField] GameObject enemy;
    public GameObject TankEnemy;
    public GameObject FastEnemy;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemys", 2f, 0.8f);
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnEnemys()
    {
        if (Player != null)
        {
            int index = Random.Range(0, spawnPoints.Length); //seleciona um numero aleatorio do vetor de spawns
            
            if (Random.Range(0, 3) == 0)
            {
                Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
            }
            if (Random.Range(0, 3) == 1)
            {
                Instantiate(TankEnemy, spawnPoints[index].position, Quaternion.identity);
            }
            if (Random.Range(0, 3) == 2)
            {
                Instantiate(FastEnemy, spawnPoints[index].position, Quaternion.identity);
            }
        }
    }
}
