using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{    
    public GameObject[] obstacles;
    public float timerSpawn;
    public float obstacleSpeedMovement;

    private List<Vector3> listPosition = new List<Vector3>();

    void Start()
    {
        int i = -5;
        while (i <= 5)
        {
            Vector3 pos = transform.position + new Vector3(0, 0, i);
            listPosition.Add(pos);
            i += 2;
        }

        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(timerSpawn);

        if (FindObjectOfType<GroundManager>().finishMoveGround)
        {
            int indexPositionOfObstacle = Random.Range(0, listPosition.Count);


            GameObject currentObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], 
                listPosition[indexPositionOfObstacle] + new Vector3(10,0,0), Quaternion.identity);

            StartCoroutine(SpawnObstacle());
        }
    }
}
