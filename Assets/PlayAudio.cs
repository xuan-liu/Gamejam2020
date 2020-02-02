using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AK.Wwise.Event Environment;

    [SerializeField] int EnvironmentLevel = 0;
    public AK.Wwise.Event ELevel1;
    public AK.Wwise.Event ELevel2;
    public AK.Wwise.Event ELevel3;
    public AK.Wwise.Event ELevel4;
    public AK.Wwise.Event ELevel5;
    public AK.Wwise.Event ELevel6;

    public AK.Wwise.State SLevel1;





    //public AK.Wwise.Event Envrionment;
    // Start is called before the first frame update
    void Start()
    {
        Environment.Post(gameObject);
        SLevel1.SetValue();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnvironmentLevel <= 0) ELevel1.Post(gameObject);

        if (EnvironmentLevel >= 0 && EnvironmentLevel < 100) ELevel1.Post(gameObject);
        if (EnvironmentLevel >= 100 && EnvironmentLevel < 200) ELevel2.Post(gameObject);
        if (EnvironmentLevel >= 200 && EnvironmentLevel < 300) ELevel3.Post(gameObject);
        if (EnvironmentLevel >= 300 && EnvironmentLevel < 400) ELevel4.Post(gameObject);
        if (EnvironmentLevel >= 400 && EnvironmentLevel < 500) ELevel5.Post(gameObject);
        if (EnvironmentLevel >= 500 && EnvironmentLevel < 600) ELevel6.Post(gameObject);

        if (EnvironmentLevel >= 600) ELevel6.Post(gameObject);

    }
}
