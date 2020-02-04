using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public GameObject dialogUI;
    public static bool GameIsPaused;

    public int statenumber = 0;

    GameManager manager;


    //singleton
    public static PlayerCollision instance;
    void Awake()
	{
        instance = this;
	}


    void Start()
    {
        manager = GameManager.instance;

        manager.ShowFirstStory();
        Time.timeScale = 0f;
        GameIsPaused = true;
        dialogUI.SetActive(true);
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Items"))
        //{
        //    //Step 1: print out to console what happens in this if statement
        //    Debug.Log("hit a cube! generate a dialog");
        //    manager.score++;
        //    manager.ChangeIsland(manager.score);            

        //    dialogUI.SetActive(true);
        //    manager.ShowStory(manager.score);
        //    Time.timeScale = 0f;
        //    GameIsPaused = true;

        //    Destroy(collision.gameObject); //delete what we collided with. The cube will disappear
        //    // if we just typed "gameObject", the player would get deleted // not cube, since this script will be connected to the player.
        //}
        //else if (collision.collider.CompareTag("Respawn"))
        //{
        //    manager.ResetToStart();
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger");

        if (other.tag == "Items")
        {
            //Step 1: print out to console what happens in this if statement
            
            manager.score++;
            manager.scoreText.text = manager.score.ToString() + "/5 Memories";
            statenumber++;


            if (statenumber == 0)
			{
                PlayAudio.instance.PlaySad();
                PlayAudio.instance.PlaySand();
                PlayAudio.instance.ELevel1.Post(gameObject);
                Debug.Log("State 1");
            }


            if (statenumber == 1)
			{
                PlayAudio.instance.PlaySad();
                PlayAudio.instance.PlaySand();
                PlayAudio.instance.ELevel2.Post(gameObject);
                Debug.Log("State 2"); 
            }


            if (statenumber == 2)
			{
                PlayAudio.instance.PlayHappy();
                PlayAudio.instance.PlayDryGrass();
                PlayAudio.instance.ELevel3.Post(gameObject);
                Debug.Log("State 3"); 
            }


            if (statenumber == 3)
			{
                PlayAudio.instance.PlayHappy();
                PlayAudio.instance.PlayDryGrass();
                PlayAudio.instance.ELevel4.Post(gameObject);
                Debug.Log("State 4"); 

            }


            if (statenumber == 4)
            {
                PlayAudio.instance.PlayHappy();
                PlayAudio.instance.PlayGrass();
                PlayAudio.instance.ELevel5.Post(gameObject);
                Debug.Log("State 5");

            }


            if (statenumber == 5)
            {
                PlayAudio.instance.PlayHappy();
                PlayAudio.instance.PlayGrass();
                PlayAudio.instance.ELevel6.Post(gameObject);
                Debug.Log("State 6");
            }


            manager.ChangeIsland(manager.score);

            dialogUI.SetActive(true);

            manager.ShowStory(manager.score);
            Time.timeScale = 0f;
            GameIsPaused = true;

            Destroy(other.gameObject); //delete what we collided with. The cube will disappear
        }
    }


    void Update()
    {
        if (GameIsPaused = true && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("finish the dialog, continue the game!");
            GameIsPaused = false;
            dialogUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
