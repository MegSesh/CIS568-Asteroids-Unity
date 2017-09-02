using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public Vector3 thrust;
    public Quaternion heading;

	// Use this for initialization
	void Start () {

        //travel straight in the X-axis
        thrust.x = 400.0f;

        //don't passively decelerate 
        GetComponent<Rigidbody>().drag = 0;

        //set the direction it will travel in
        GetComponent<Rigidbody>().MoveRotation(heading);

        //apply thrust once, no need to apply it again
        //since it won't decelerate
        GetComponent<Rigidbody>().AddRelativeForce(thrust);
	}
	
	// Update is called once per frame
	void Update () {
		//physics engine handles movement, empty for now
	}

    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;

        if(collider.CompareTag("Asteroid"))
        {
            Asteroid roid = collider.gameObject.GetComponent<Asteroid>();

            roid.Die();

            Destroy(gameObject);
        }

        else
        {
            Debug.Log("Collided with " + collider.tag);
        }
    }
}
