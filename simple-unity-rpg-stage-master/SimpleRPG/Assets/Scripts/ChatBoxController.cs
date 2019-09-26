using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBoxController : MonoBehaviour
{
    public InputField InputText;
    public Text text;
    private Rect windowRect = new Rect((Screen.width) / 2, (Screen.height) / 2, 200, 300);
    private bool show = false;
    public int id = 0;
    public void ScanText()
    {
        text.text = InputText.text;
    }

    void OnGUI()
    {
        if (show)
            windowRect = GUI.Window(id, windowRect, DialogWindow, text.text);
    }

    // This is the actual window.
    void DialogWindow(int windowID)
    {
        if (windowID == 0)
        {
            float y = 20;
            if (GUI.Button(new Rect(0, y, windowRect.width , 30), "OK"))
            {
                show = false;
            }
        }
        else if(windowID == 1)
        {
            float y = 20;
            if (GUI.Button(new Rect(0, y, windowRect.width, 30), "Yes"))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
                show = false;
            }
            if (GUI.Button(new Rect(0, y + 40, windowRect.width, 30), "No"))
            {
                Application.LoadLevel(0);
                show = false;
            }
        }
    }

    // To open the dialogue from outside of the script.
    public void Open()
    {
        show = true;
    }
}
