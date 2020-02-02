using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;

    public float speed = 1;
    float dis;
    enum State { Start, End};
    State state;

    public const float closeThreshold = 0.001f;


    // Start is called before the first frame update
    void Start()
    {
        dis = Vector3.Distance(end, start);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(start, end, Mathf.PingPong(Time.time, 1.0f));

        switch (state)
        {
            case State.Start:
                transform.position = Vector3.Lerp(transform.position, end, speed * Time.deltaTime);
                if(Vector3.Distance(transform.position, end) < closeThreshold)                
                    state = State.End;
                break;
            case State.End:
                transform.position = Vector3.Lerp(transform.position, start, speed * Time.deltaTime);
                if(Vector3.Distance(transform.position, start) < closeThreshold)                
                    state = State.Start;
                break;

        }
    }
}
