using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public GameObject dialogUI;
    public static bool GameIsPaused;

    Manager manager;

    void Start()
    {
        manager = Manager.instance;

        //DialogCanvas = GetComponent<Canvas>();
        dialogUI.SetActive(false);
        GameIsPaused = false;
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Items"))
        {
            //Step 1: print out to console what happens in this if statement
            Debug.Log("hit a cube! generate a dialog");
            manager.score++;
            manager.ChangeIsland(manager.score);            

            dialogUI.SetActive(true);
            manager.ShowStory(manager.score);
            Time.timeScale = 0f;
            GameIsPaused = true;

            Destroy(collision.gameObject); //delete what we collided with. The cube will disappear
            // if we just typed "gameObject", the player would get deleted // not cube, since this script will be connected to the player.
        }
        else if (collision.collider.CompareTag("Respawn"))
        {
            manager.ResetToStart();
        }
        else if (collision.collider.CompareTag("Finish"))
        {
            manager.ResetToStart();
        }
    }

    void Update()
    {
        if (GameIsPaused = true && Input.GetMouseButtonDown(0))
        {
            Debug.Log("finish the dialog, continue the game!");
            GameIsPaused = false;
            dialogUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
