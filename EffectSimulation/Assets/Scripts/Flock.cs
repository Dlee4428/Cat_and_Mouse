using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] DataInt maxBoids;
    [Header("References")]
    [SerializeField] private Data data;
    [SerializeField] GameObject boid;
    [SerializeField] List<GameObject> boids = new List<GameObject>();
    [SerializeField] GameObject[] obstacles;
    [SerializeField] List<GameObject> obstacleList = new List<GameObject>();

    private int maxData;

    // Start is called before the first frame update
    void Start()
    {
        maxBoids = data.Int(maxBoids);

        for (int i = 0; i < (int)maxBoids; i++)
        {
            boids.Add(Instantiate(boid, Vector3.zero, transform.rotation));
        }

        foreach (GameObject boid in boids)
        {
            boid.SetActive(true);
            boid.GetComponent<Boids>().flock = this;
        }

        // obstacles
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        obstacleList = new List<GameObject>(obstacles);
        Debug.Log(obstacles.Length);
    }


    // Update is called once per frame
    void Update()
    {

    }

    public List<GameObject> GetBoidList()
    {
        return boids;
    }

    public List<GameObject> GetObstacleList()
    {
        return obstacleList;
    }
}
