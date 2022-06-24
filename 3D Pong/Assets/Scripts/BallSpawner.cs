using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public Transform ballParent;
    public List<Transform> spawnerPosition;
    public List<GameObject> ballList = new List<GameObject>();
    public int maxBall;

    private float timer;
    public float spawnInterval;

    // Start is called before the first frame update
    private void Start()
    {
        GenerateBall(Random.Range(0, spawnerPosition.Count));
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateBall(Random.Range(0, spawnerPosition.Count));
            timer -= spawnInterval;
        }
    }

    public void GenerateBall(int _indexSpawner)
    {
        if (ballList.Count == maxBall)
        {
            return;
        }
        GameObject ballTemp = Instantiate(ball, spawnerPosition[_indexSpawner].position, spawnerPosition[_indexSpawner].rotation, ballParent);
        ballTemp.GetComponent<BallController>().positionIndex = _indexSpawner;
        ballList.Add(ballTemp);
    }

    public void RemoveBall(GameObject _ball)
    {
        ballList.Remove(_ball);
        Destroy(_ball);
    }
}