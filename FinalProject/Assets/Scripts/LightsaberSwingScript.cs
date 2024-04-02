using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberSwingScript : MonoBehaviour
{
    //Lightsaber gameobject
    public GameObject Lightsaber;

    //Add a cooldown so the player cannot spam attack and bug the animation
    public float cooldownTime = 1f;
    private float lastUsedTime;

    

    // Start is called before the first frame update
    void Start()
    {
        //turn off lightsaber hitbox on start
        GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If left mouse button is clicked then start the animation
        if(Input.GetMouseButtonDown(0) && Time.time > lastUsedTime + cooldownTime)
        {
            //enable lightsaber hitbox when attacking
            GetComponent<Collider>().enabled = true;
            //animation
            StartCoroutine(LightsaberSwing());
            //update cooldown
            lastUsedTime = Time.time;
        }
    }

    IEnumerator LightsaberSwing()
    {
        Lightsaber.GetComponent<Animator>().Play("LightsaberSwing");
        yield return new WaitForSeconds(1.0f);
        Lightsaber.GetComponent<Animator>().Play("New State");

        //turn off lightsaber hitbox when the animation is over
        GetComponent<Collider>().enabled = false;
    }
}
