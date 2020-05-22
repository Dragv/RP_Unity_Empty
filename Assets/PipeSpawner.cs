using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipeline;
    public Transform despawningPosition;
    public float lowerLimit;
    public float upperLimit;
    private Queue<GameObject> pipes = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLine", 2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (pipes.Count > 0 && pipes.Peek().transform.position.x < despawningPosition.position.x)
        {
            GameObject killedObject = pipes.Dequeue();
            Destroy(killedObject);
        }
    }

    void SpawnLine()
    {
        OffsetTransform();
        GameObject go = Instantiate(pipeline, transform.position, pipeline.transform.rotation);
        pipes.Enqueue(go);
    }

    void OffsetTransform()
    {
        float modifier = Random.Range(-1, 1);
        if (transform.position.y + modifier < lowerLimit || transform.position.y + modifier > upperLimit)
        {
            modifier *= -1.0f;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + modifier, transform.position.z);
    }

    public void DeleteAll() 
    {
        while (pipes.Count >= 0)
        {
            GameObject killedObject = pipes.Dequeue();
            Destroy(killedObject);

        }
    }
}
