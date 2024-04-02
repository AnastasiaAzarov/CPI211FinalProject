using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour

{
	public int PlayerHealth = 3;

    void Start()
    {
        Debug.Log(PlayerHealth);
    }

    // Start is called before the first frame update
    void OnCollisionEnter(Collision col)
	{
		if(col.collider.gameObject.transform.tag == "Enemy")
		{
			PlayerHealth--;
            Debug.Log(PlayerHealth);
            //Destroy(col.gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (col.collider.gameObject.transform.tag == "Enemy" && PlayerHealth == 0)
        {
            PlayerHealth = 3;
            Destroy(col.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
