using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject grounTile;
    Vector3 nextSpawnPoint;


    public void spawnTile()
    {
        GameObject temp = Instantiate(grounTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    }

    private void Start()
    {

        for (int i = 0; i < 10; i++)
        {

            spawnTile();

        }
    }
}
