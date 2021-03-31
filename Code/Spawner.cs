using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject pinSpawned;
    public Transform canvas;
    public Transform spawnPin;
    


    private void Update()
    {
    
    }

    public void SpawnPinP1()
    {
        pinSpawned = Instantiate(pinPrefab, new Vector3(0, 0, 0), transform.rotation);
        pinSpawned.transform.SetParent(canvas, false);
    }

    public void SpawnPinP2()
    {
        pinSpawned = Instantiate(pinPrefab, new Vector3(0, 0, 0), transform.rotation);
        pinSpawned.transform.SetParent(canvas, false);
    }

}
