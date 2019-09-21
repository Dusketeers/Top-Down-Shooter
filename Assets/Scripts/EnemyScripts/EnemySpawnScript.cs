using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private bool canSpawn = true;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            SpawnGits();
        }
    }

    public void SpawnGits()
    {
        int enemyNum = Random.Range(4, 10);
        for(int i = 0; i < enemyNum; i++)
        {
            GameObject temp = Instantiate(enemy, transform);
            RandomNudge(temp);
        }
        StartCoroutine(PauseSpawning());
    }

    public void RandomNudge(GameObject gO)
    {
        Vector3 temp = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        gO.GetComponent<Rigidbody2D>().AddForce(temp);
    }

    IEnumerator PauseSpawning()
    {
        paused = true;
        yield return new WaitForSeconds(Random.Range(2f, 6f));
        paused = false;
    }
}
