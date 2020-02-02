using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandRaising : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;

    bool isMoving = false;

    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = start;
    }

    private void OnEnable()
    {
        isMoving = true;
    }
    private void OnDisable()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, end, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, end) < 0.1f)
                isMoving = false;
        }
    }
}
