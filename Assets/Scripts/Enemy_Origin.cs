using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Origin : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationSpeed = new Vector3(0f, 50f, 0f);

    [SerializeField]
    private float offset = 10f;


    [SerializeField]
    private float Y_offset = 5f;

    [SerializeField]
    private int numberOfEnemy = 5;
    private GameObject nodeObj;
    private GameObject[] nodeArray;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnRadius = 13f;
    private Vector3 spawnPos;

    public static Vector2 RandomPointOnUnitCircle(float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float z = Mathf.Cos(angle) * radius;

        return new Vector2(x, z);
    }

    void Start()
    {
        nodeArray = new GameObject[numberOfEnemy];
        foreach (GameObject node in nodeArray)
        {
            // nodeObj = new GameObject("node");
            //nodeObj.transform.position = this.transform.position + new Vector3(offset, Random.Range(-Y_offset, Y_offset), 0f);
            //nodeObj.transform.SetParent(this.transform);
            Vector2 rpoc = RandomPointOnUnitCircle(spawnRadius);
            spawnPos = new Vector3(rpoc.x, 0f, rpoc.y);
            Instantiate(enemyPrefab, spawnPos + transform.position, Quaternion.identity);
            //lastNode.transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
