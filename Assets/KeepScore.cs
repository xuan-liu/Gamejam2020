using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScore : MonoBehaviour
{
    public static int Score= 0; //Initialize the score to zero

    private void OnGUI()
    {
        // Create style for a button
        GUIStyle myTextStyle = new GUIStyle(GUI.skin.button);
        myTextStyle.fontSize = 50;

        //// Load and set Font
        //Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
        //myTextStyle.font = myFont;
        //// Set color for selected and unselected buttons
        //myTextStyle.normal.textColor = Color.red;
        //myTextStyle.hover.textColor = Color.red;


        //OnGUI is called for rendering and handling GUI events.
        GUI.Box(new Rect(10, 10, 250, 150), "Score: " + Score.ToString(), myTextStyle);
        //Creates a rectangle in the top left of the screen to display score
    }
}
