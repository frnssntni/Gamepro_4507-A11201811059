using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_y = -4.24f, max_y = 4.24f;
    public GameObject meteorit;
    public GameObject EnemyUfo;
    public float timer = 2f;
    public int score = 0;

    void Start()
    {
        Invoke("SpawnEnemy", timer);
    }

    void SpawnEnemy(){
        float pos_y = Random.Range(min_y,max_y);
        Vector3 temp =transform.position;
        temp.y = pos_y;

        if(Random.Range(0,2) > 0){
            Instantiate(meteorit, temp, Quaternion.identity);
        }
        else {
            Instantiate(EnemyUfo, temp, Quaternion.Euler(0f, 0f, 0f));
        }

        Invoke("SpawnEnemy", timer);
        score++;
    }

    void OnGUI(){
        GUI.color = Color.white;
        GUILayout.Label("SCORE: " + score.ToString());
    }
}
   
