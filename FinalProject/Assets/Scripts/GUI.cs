using UnityEngine;

public class GUIManager : Kills
{
        void OnGUI()
        {
        GUIStyle killTextStyle = new GUIStyle(GUI.skin.label);
        killTextStyle.fontSize = (int)(40 * 0.7f);
        killTextStyle.alignment = TextAnchor.UpperRight;
        killTextStyle.fontStyle = FontStyle.Bold;
        killTextStyle.normal.textColor = new Color(255f/255, 175f/255, 145f/255);
        int killWidth = (int)(280 * 0.7f);
        int killHeight = (int)(120 * 0.7f);
        Rect killTextArea = new Rect(Screen.width - killWidth - 20, 20, killWidth, killHeight);
        //GUI.Label(killTextArea, "Kills: " + base.kills, killTextStyle);
        
        GUIStyle commandTextStyle = new GUIStyle(GUI.skin.label);
        commandTextStyle.fontSize = (int)(20 * 0.7f);
        commandTextStyle.alignment = TextAnchor.LowerRight;
        commandTextStyle.fontStyle = FontStyle.Bold;
        commandTextStyle.normal.textColor = new Color(105f/255, 180f/255, 200f/255);
        int commandWidth = (int)(560 * 0.7f);
        int commandHeight = (int)(220 * 0.7f);
        Rect commandTextArea = new Rect(Screen.width - commandWidth - 20, Screen.height - commandHeight - 20, commandWidth, commandHeight);
        string commandsText = "Themes - Storytelling\nHe That Fights and Runs Away May Live to Fight Another Day\nUse sword - Left click\nWASD - Movement\nSpace - Jump";
        GUI.Label(commandTextArea, commandsText, commandTextStyle);
    }
    
}
