using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationAudio : MonoBehaviour
{
    public AK.Wwise.Event Walk;

    public AK.Wwise.Switch WalkMode;



    public void PlayWalk()
    {
        Walk.Post(gameObject);
    }



    // Start is called before the first frame update
    void Awake()
    {
        WalkMode.SetValue(gameObject);

    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
