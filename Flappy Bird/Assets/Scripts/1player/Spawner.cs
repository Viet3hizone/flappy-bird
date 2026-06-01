using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Pipe;
    private GameObject pipes;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        int score = FindObjectOfType<GameManager>().score; 
        if(score > 6 )  pipes = Instantiate(Pipe, transform.position, Quaternion.Euler(0,0,Random.Range(-30,30)));
        else pipes = Instantiate(Pipe, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}


