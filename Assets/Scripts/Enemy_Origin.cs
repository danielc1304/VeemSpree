using System.Collections;
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

    [SerializeField] private Vector2 min_maxSpawnTime = new Vector2(8f,15f);
    private Coroutine spawnCoroutine;
    private float spawnTime;

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
            spawnTime = Random.Range(min_maxSpawnTime.x, min_maxSpawnTime.y);
            Instantiate(enemyPrefab, spawnPos + transform.position, Quaternion.identity);
            StartCoroutine(spawnEnemy(spawnTime));
            //lastNode.transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator spawnEnemy(float time)
    {
        Vector2 rpoc = RandomPointOnUnitCircle(spawnRadius);
        spawnPos = new Vector3(rpoc.x, 0f, rpoc.y);
        Instantiate(enemyPrefab, spawnPos + transform.position, Quaternion.identity);
        spawnTime = Random.Range(min_maxSpawnTime.x,min_maxSpawnTime.y);
        yield return new WaitForSeconds(time);
        if (spawnCoroutine != null)
            StopCoroutine(spawnCoroutine);
        spawnCoroutine = StartCoroutine(spawnEnemy(spawnTime));
    }


    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
