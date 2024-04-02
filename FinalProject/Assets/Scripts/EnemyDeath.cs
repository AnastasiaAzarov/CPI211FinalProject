using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int EnemyHealth = 1;

    public Kills playerKills;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.transform.tag == "Saber")
        {
            Debug.Log("Enemy Hit");
            EnemyHealth--;
            //Destroy(col.gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (col.collider.gameObject.transform.tag == "Saber" && EnemyHealth == 0)
        {
            playerKills = GameObject.Find("GameController").GetComponent<Kills>();
            playerKills.incrementKills();
            Debug.Log("Player Kills: " + playerKills.kills.ToString());
            Destroy(this.gameObject);

        }
    }
}
