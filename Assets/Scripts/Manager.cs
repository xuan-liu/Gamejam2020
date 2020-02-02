using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public string[] stories = {"story 0", "story 1", "story 2",
        "story 3", "story 4", "story 5",
        "story 6", "story 7", "story 8",
        "story 9", "story 10", "story 11",
        "story 12", "story 13", "story 14",
        "story 15", "story 16", "story 17",
        "story 18", "story 19", "story 20" };

    public GameObject firstIsland;
    public GameObject secondIsland;
    public GameObject thirdIsland;
    public GameObject level1;
    public GameObject platformX1;
    public Transform reset;
    public Transform finish1;
    public Transform reset2;

    public bool finishOneTime = false;
    public bool resetOneTime = false;
    public int score = 0;

    public const int scoreToYellowFirst = 3;
    public const int scoreToSecondIsland = 6;
    public const int scoreToYellowSecond = 9;
    public const int scoreToThirdIsland = 12;
    public const int scoreToYellowThird = 15;
    public const int scoreToFinish = 18;

    public Texture[] firstTextures;
    public Texture[] secondTextures;
    public Texture[] thirdTextures;

    public Text text;

    public GameObject player;
    public Transform startTrans;

    // current level of the game
    public int level = 0;

    public void Awake()
    {
        instance = this;
    }

    public void ResetToStart()
    {
        player.transform.position = startTrans.position;
    }

    public void LevelTransition(int level)
    {
        if (level == 0)
        {
            // level 1 falls down
            foreach (Transform child in level1.transform)
            {
                StartCoroutine(PlatformFallingIE(child.gameObject, reset));
            }
            ChangeIslandColor(0, 1);

            // platform x moves to island2
            var movement = platformX1.GetComponent<PlatformMovement>();
            movement.isMoving = false;
            movement.start = movement.gameObject.transform.position;
            movement.end = reset2.position;
            movement.speed = 0.1f;
            movement.isMoving = true;

            // island 2 rising
            secondIsland.gameObject.SetActive(true);
        }



    }


    IEnumerator PlatformFallingIE(GameObject platform, Transform end)
    {
        float a = 2f;
        float v = 0;
        float y = platform.transform.position.y;
        while (Vector3.Distance(platform.transform.position, end.position) > 0.1f)
        {
            float t = Time.deltaTime;
            v += a * t;
            y -= v * t + 0.5f * a * t * t;
            platform.transform.position = new Vector3(platform.transform.position.x, y, platform.transform.position.z);
            yield return null;
        }
    }


    public void ChangeIsland(int score)
    {
        switch (score)
        {
            case scoreToYellowFirst:
                ChangeIslandColor(0, 1);
                break;

            case scoreToSecondIsland:
                ChangeIslandColor(0, 2);
                ShowSecondIsland();
                ChangeIslandColor(1, 0);
                break;

            case scoreToYellowSecond:
                ChangeIslandColor(1, 1);
                break;

            case scoreToThirdIsland:
                ChangeIslandColor(1, 2);
                ShowThirdIsland();
                ChangeIslandColor(2, 0);
                break;
            case scoreToYellowThird:
                ChangeIslandColor(2, 1);
                break;
            case scoreToFinish:
                ChangeIslandColor(2, 2);
                break;
        }
    }

    public void ShowStory(int score)
    {
        if (score < stories.Length)
        {
            text.text = stories[score];
        }
        else
            Debug.LogError("score out of story length!");
    }


    public void ShowSecondIsland()
    {
        secondIsland.SetActive(true);
    }
    public void ShowThirdIsland()
    {
        thirdIsland.SetActive(true);
    }

    public void ChangeIslandColor(int i, int j)
    {
        switch (i)
        {
            case 0:
                firstIsland.GetComponent<Renderer>().material.SetTexture("_MainTex", firstTextures[j]);
                break;
            case 1:
                secondIsland.GetComponent<Renderer>().material.SetTexture("_MainTex", secondTextures[j]);
                break;
            case 2:
                thirdIsland.GetComponent<Renderer>().material.SetTexture("_MainTex", thirdTextures[j]);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        firstIsland.SetActive(true);
        ChangeIslandColor(0, 0);
        secondIsland.SetActive(false);
        thirdIsland.SetActive(false);

        ResetToStart();
    }

    // Update is called once per frame
    void Update()
    {


        if (player.transform.position.y > finish1.position.y)
        {
            if (level == 0 && finishOneTime == false)
            {
                finishOneTime = true;
                LevelTransition(level);
                level++;

            }
        }

    }

    void LateUpdate()
    {
        if (player.transform.position.y < reset.position.y)
        {
            ResetToStart();
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<CharacterController>().enabled = true;

        }
    }
}
