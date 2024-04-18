using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LightsaberSwingScript : MonoBehaviour
{
    //Lightsaber gameobject
    public GameObject Lightsaber;

    //Add a cooldown so the player cannot spam attack and bug the animation
    public float SwingcooldownTime = 1f;
    public float ThrowcooldownTime = 5f;
    private float SwinglastUsedTime;
    private float ThrowlastUsedTime;

    public PlayableDirector anim;


    

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
        if(Input.GetMouseButtonDown(0) && Time.time > SwinglastUsedTime + SwingcooldownTime)
        {
            //enable lightsaber hitbox when attacking
            GetComponent<Collider>().enabled = true;
            //animation
            StartCoroutine(LightsaberSwing());
            
            //update cooldown
            SwinglastUsedTime = Time.time;
        }

        if (Input.GetMouseButtonDown(1) && Time.time > ThrowlastUsedTime + ThrowcooldownTime)
        {
            //enable lightsaber hitbox when attacking
            GetComponent<Collider>().enabled = true;
            //animation
            StartCoroutine(LightsaberThrow());
            
            //update cooldown
            ThrowlastUsedTime = Time.time;
            Debug.Log("Throw");
        }
    }
    
    IEnumerator LightsaberSwing()
    {
        Lightsaber.GetComponent<PlayableDirector>().Play();
        yield return new WaitForSeconds(1.0f);
        Lightsaber.GetComponent<PlayableDirector>().Stop();

        //turn off lightsaber hitbox when the animation is over
        GetComponent<Collider>().enabled = false;
    }

    IEnumerator LightsaberThrow()
    {
        anim.GetComponent<PlayableDirector>().Play();
        yield return new WaitForSeconds(1.0f);
        anim.GetComponent<PlayableDirector>().Stop();

        //turn off lightsaber hitbox when the animation is over
        GetComponent<Collider>().enabled = false;
    }
    
   
}
