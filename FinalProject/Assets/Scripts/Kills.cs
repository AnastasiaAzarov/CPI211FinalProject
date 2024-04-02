using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kills : MonoBehaviour
{
    public int kills;
    // Start is called before the first frame update
    void Start()
    {
        kills = 0;
    }
    // Update is called once per frame
    public void incrementKills() {
        kills++;
    }
}
