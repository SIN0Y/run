using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class groundTile : MonoBehaviour
{
     GroundSpawner groundSpawner;
    public GameObject obstacles;
    public GameObject conPrefabs;
   



    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
     
        
        spawnCoin();
        obstacleSpawner();



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            groundSpawner.spawnTile();
            Destroy(gameObject, 2f);
        }
    }

     void obstacleSpawner()
    {
        
            int obstacleSpawnerIndex = Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(obstacleSpawnerIndex).transform;
            Instantiate(obstacles, spawnPoint.position, Quaternion.identity, transform);  
        
    }

   

    void spawnCoin()
    {
        for (int i = 0; i < 3; i++)
        {
            
             GameObject temp= Instantiate(conPrefabs,transform);
            temp.transform.position = RandomPointInCollider(GetComponent<Collider>());
            
        }
    }


  

    Vector3 RandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = RandomPointInCollider(collider);
        }
        point.y = 1; return point;
        }

 
}
