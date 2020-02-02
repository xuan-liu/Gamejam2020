using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    //public static bool GamePaused;
    public GameObject PauseMenuUI;
    // drag the PausePanel into the Canvas inspector to link

    // Start is called before the first frame update
    void Start()
    {
        //GamePaused = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // normal time
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape!");
            PauseMenuUI.SetActive(true); // make the menu appear
            Time.timeScale = 0f; // stopping time
        }
    }

    //public void PlayGame() {
    //    Debug.Log("Play Button clicked");
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    //public void Pause(){
    //    PauseMenuUI.SetActive(true); // make the menu appear
    //    Time.timeScale = 0f; // stopping time
    //    GameIsPaused = true;
    //}

    public void Resume()
    {
        PauseMenuUI.SetActive(false); // make the menu disappear
        Time.timeScale = 1f; // starting time
        //GameIsPaused = false;
    }

    //public void RestartGame() {
    //    Debug.Log("Restart button clicked");
    //    GameIsPaused = false;
    //    Time.timeScale = 1f;

    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    // load the currently active scene (our game)
    //    // need to type "using UnityEngine.SceneManagement;" at the top of the file
    //}

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

