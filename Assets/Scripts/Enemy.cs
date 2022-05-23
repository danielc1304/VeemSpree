using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject enemyOrigin;
    [SerializeField]
    private Vector2 min_maxRotationSpeed;
    private float rotationSpeed;

    [SerializeField]
    private Vector2 min_maxLerpSpeed;
    private float lerpSpeed = 0.1f;

    [SerializeField]
    private AnimationCurve spawnCurve;
    private float y_offset = 7f;
    private float destination;
    private float current;

    [SerializeField]
    private Vector2 min_maxHeightOffset;
    [SerializeField]
    private Vector2 min_maxChangeTimer;
    private float destTime;
    private Coroutine moveCoroutine;

    void Start()
    {
        destination = transform.position.y;
        transform.position += new Vector3(0, -y_offset, 0);
        enemyOrigin = GameObject.FindGameObjectWithTag("Origin");
        rotationSpeed = Random.Range(min_maxRotationSpeed.x, min_maxRotationSpeed.y);
        destTime = Random.Range(min_maxChangeTimer.x, min_maxChangeTimer.y);
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(changeDestination(2f));
    }

    void Update()
    {
        current = Mathf.MoveTowards(current, destination, lerpSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, destination, spawnCurve.Evaluate(current)),transform.position.z);
        transform.RotateAround(enemyOrigin.transform.position, new Vector3(0, 1, 0),rotationSpeed * Time.deltaTime);
    }

    IEnumerator changeDestination(float time)
    {
        yield return new WaitForSeconds(time);
        lerpSpeed = Random.Range(min_maxLerpSpeed.x, min_maxLerpSpeed.y);
        destTime = Random.Range(min_maxChangeTimer.x, min_maxChangeTimer.y);
        destination = enemyOrigin.transform.position.y + Random.Range(min_maxHeightOffset.x, min_maxHeightOffset.y);
        rotationSpeed = rotationSpeed * generateRandomInt();
        Debug.Log("Cambio");
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(changeDestination(destTime));
    }

    private int generateRandomInt()
    {
        int value;
        value = Random.Range(-1, 1);
        while(value == 0)
        {
            value = Random.Range(-1, 1);
        }
        return value;
    }
}
