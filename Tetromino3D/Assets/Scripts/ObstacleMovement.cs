using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.position +  Vector3.left * FindObjectOfType<ObstacleSpawner>().obstacleSpeedMovement * Time.deltaTime;
    }

    private void OnBecameVisible()
    {
        Destroy(gameObject);
    }
}
