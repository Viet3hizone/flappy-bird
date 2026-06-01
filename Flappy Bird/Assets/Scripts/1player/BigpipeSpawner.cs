using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigpipeSpawner : MonoBehaviour
{
    public GameObject Bigpipe;
    float spawnrate = 3f;
    float min = -1f;
    float max = 1f;
    void OnEnable()
    {
        InvokeRepeating(nameof(spawn), spawnrate, spawnrate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(spawn));
    }
    void spawn()
    {
        GameObject bigpipe = Instantiate(Bigpipe, transform.position, Quaternion.Euler(0, 0, Random.Range(-15f, 15f)));
        bigpipe.transform.position += Vector3.up * Random.Range(min, max);
    }
}
