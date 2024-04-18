using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePull : MonoBehaviour
{
    [Tooltip ("Hand that is the target destination of the pull")]
    public Transform hand;

    [Tooltip ("Tag that is used to determine if an object is pullable or not")]
    public string pullableTag;

    [Tooltip ("Force modifier, tweak to whatever (The higher the modifier the faster the object will go towards the hand)")]
    public float modifier = 1.0f;

    [Tooltip ("The direction of the force that is pulling the object")]
    Vector3 pullForce;

    [Tooltip("Once an object is in hand, save it to this variable")]
    public Transform heldObject;

    [Tooltip("The distance threshhold in which the object is considered pulled to the hand")]
    public float positionDistanceThreshhold;

    [Tooltip("The distance threshold in which the object's velocity is set to maximum")]
    public float velocityDistanceThreshold;

    [Tooltip("The maximum velocity of the object being pulled")]
    public float maxVelocity;

    [Tooltip("The velocity at whiuch the object is thrown")]
    public float throwVelocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast (transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag.Equals (pullableTag))
                {
                    Debug.Log("Searching");
                    StartCoroutine(PullObject(hit.transform));
                  
                }
            }
        }

        

        /* 
         * If the player pressed G then do the following:
         * 1) make its parent be nothing
         * 2) Remove all physics constraints
         * 3) Set its velocity to be the forward vector of the camera * the throw velocity
         * 4) Set the heldObject variable to null
        */
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (heldObject != null)
            {
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                heldObject.GetComponent<Rigidbody>().velocity = transform.forward * throwVelocity;
                heldObject = null;
            }
        }
    }
    
   

    IEnumerator PullObject (Transform t)
    {
        Rigidbody r = t.GetComponent<Rigidbody>();
        Debug.Log("Pulling");
        while (true)
        {
            //if the player hits G, stop pulling
            if (Input.GetKeyDown(KeyCode.G))
            {
                break;
            }
            float distanceToHand = Vector3.Distance(t.position, hand.position);
            /*
             * If the object is within the distance threshhold, consider it pulled all the way 
             * 1) Set the object's position to the hand position
             * 2) make its parent be the hand object
             * 3) Constrain its movement, but not rotation (for realism)
             * 4) Set its velocity to be the forward vector of the the camera * the throw velocity
             * 5) Break out of the coroutine
             */
            if (distanceToHand < positionDistanceThreshhold)
            {
                t.position = hand.position;
                t.parent = hand;
                r.constraints = RigidbodyConstraints.FreezePosition;
                heldObject = t;
                Debug.Log("Bruh");
                break;
            }

            //Calculate the pull direction (destination - origin)
            Vector3 pullDirection = hand.position - t.position;

            //Normalize (return the vector with a magnitude of 1) it and multiply by the force modifier
            pullForce = pullDirection.normalized * modifier;

            
            // Check if the velocity magnitude of the object is less than the maximum velocity and check if the distance to the hand is greater than the distance threshold

            if (r.velocity.magnitude < maxVelocity && distanceToHand > velocityDistanceThreshold)
            {
                //Add force that takes the object's mass into account (realism)
                r.AddForce(pullForce, ForceMode.Force);
            } else
            {
                //Set a constant velocity to the object
                r.velocity = pullDirection.normalized * maxVelocity;
            }

            yield return null;
        }
    }
}
