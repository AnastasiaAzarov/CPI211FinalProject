using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillsText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killsText;

    public Kills playerKills;
    
    // Update is called once per frame
    void Update()
    {
        playerKills = GameObject.Find("GameController").GetComponent<Kills>();
        killsText.text = "Kills: " + playerKills.kills.ToString();
    }
}
