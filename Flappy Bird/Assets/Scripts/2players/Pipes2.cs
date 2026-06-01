using UnityEngine;

public class Pipes2 : MonoBehaviour
{

    public float speed = 5f;
    private float leftEdge;
    private int score;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        score = FindObjectOfType<GameManager2>().score2;
        if (score >= 4)
        {
            if (score % 2 == 0) transform.position += new Vector3(0, -1f, 0) * Time.deltaTime;
            else transform.position += new Vector3(0, 1f, 0) * Time.deltaTime;
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

}
