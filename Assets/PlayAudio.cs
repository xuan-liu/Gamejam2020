using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AK.Wwise.Event Environment;

    [SerializeField] public int Score;

    public AK.Wwise.Event ELevel1;
    public AK.Wwise.Event ELevel2;
    public AK.Wwise.Event ELevel3;
    public AK.Wwise.Event ELevel4;
    public AK.Wwise.Event ELevel5;
    public AK.Wwise.Event ELevel6;
    public AK.Wwise.Event Jump;
    public AK.Wwise.Switch Happy;
    public AK.Wwise.Switch Sad;
    public AK.Wwise.Switch Sand;
    public AK.Wwise.Switch DryGrass;
    public AK.Wwise.Switch Grass;







    public AK.Wwise.State SLevel1;



    //Singleton
    public static PlayAudio instance;

    public void PlaySad()
    {
        Sad.SetValue(gameObject);
    }

    public void PlaySand()
    {
        Sand.SetValue(gameObject);
    }

    public void PlayDryGrass()
    {
        DryGrass.SetValue(gameObject);
    }

    public void PlayGrass()
    {
        Grass.SetValue(gameObject);
    }

    public void PlayHappy()
    {
        Happy.SetValue(gameObject);
    }

    public void PlayJump()
    {
        Jump.Post(gameObject);
    }



    //Posting according state for music and ambience, 1 to 6. 
    public void PlayTexture1()
    {
        //PlayAudio.instance.ELevel1.Post(gameObject);
        //Debug.Log("State 1"); 

    }

    public void PlayTexture2()
    {
        //ELevel2.Post(gameObject);
        //Debug.Log("State 2"); }

    }


    public void PlayTexture3()
    {
        //ELevel3.Post(gameObject);
        //Debug.Log("State 3"); 
    }


    public void PlayTexture4()
    {
        //ELevel4.Post(gameObject);
        //Debug.Log("State 4"); 
    }


    public void PlayTexture5()
    {
        //ELevel5.Post(gameObject);
        //Debug.Log("State 5"); 
    }

    public void PlayTexture6()
    {
        //ELevel6.Post(gameObject);
        //Debug.Log("State 6"); 
    }




    private void Awake()
    {
        //Singleton
        instance = this;
        SLevel1.SetValue();

    }



    // Start is called before the first frame update
    void Start()
    {
        Environment.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Score = " + GameManager.instance.score);

    }
}

