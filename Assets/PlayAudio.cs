using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AK.Wwise.Event Environment;

    [SerializeField] public int Score = 0;
    public AK.Wwise.Event ELevel1;
    public AK.Wwise.Event ELevel2;
    public AK.Wwise.Event ELevel3;
    public AK.Wwise.Event ELevel4;
    public AK.Wwise.Event ELevel5;
    public AK.Wwise.Event ELevel6;
    public AK.Wwise.Event Jump;
    public AK.Wwise.Switch Happy;
    public AK.Wwise.Switch Sad;




    public AK.Wwise.State SLevel1;



    //Singleton
    public static PlayAudio instance;

    public void PlaySad()
    {
        Sad.SetValue(gameObject);
    }

    public void PlayHappy()
    {
        Happy.SetValue(gameObject);
    }


    public void PlayJump()
    {
        Jump.Post(gameObject);
    }

    //public AK.Wwise.Event Envrionment;


    public void PlayTexture1()
    {
        if (Score <= 0) ELevel1.Post(gameObject);
        if (Score >= 0 && Score < 100) ELevel1.Post(gameObject);
        if (Score >= 100 && Score < 200) ELevel2.Post(gameObject);
    }


    public void PlayTexture2()
    {
        if (Score >= 200 && Score < 300) ELevel3.Post(gameObject);
        if (Score >= 300 && Score < 400) ELevel4.Post(gameObject);
    }


    public void PlayTexture3()
    {
        if (Score >= 400 && Score < 500) ELevel5.Post(gameObject);
        if (Score >= 500 && Score < 600) ELevel6.Post(gameObject);
        if (Score >= 600) ELevel6.Post(gameObject);
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
 
    }
}
