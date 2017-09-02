using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    //some public variables that can be used to tune the ship's movement

    //public float turnSpeed;
    //public float thrustSpeed;

    public Vector3 forceVector;
    public float rotationSpeed;
    public float rotation;
    public GameObject bullet;   //the GameObject to spawn

	// Use this for initialization
	void Start () {
        //turnSpeed = 0.5f;
        //thrustSpeed = 0.01f;

        //Vector3 default initializes all components to 0.0f
        forceVector.x = 1.0f;
        rotationSpeed = 2.0f;
	}

    /*
     * Forced changes to rigid body physics parameters should be done through
     * the FixedUpdate() method, not the Update() method
     */

    void FixedUpdate()
    {
        //force thruster
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(forceVector);
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            rotation += rotationSpeed;
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));

            GetComponent<Rigidbody>().MoveRotation(rot);

            //GetComponent<Rigidbody>().transform.Rotate(0, 2.0f, 0.0f);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            rotation -= rotationSpeed;
            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));
            GetComponent<Rigidbody>().MoveRotation(rot);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 updatedPosition = gameObject.transform.position;
        //updatedPosition.x += 0.001f;
        //gameObject.transform.position = updatedPosition;

        //if(Input.GetAxisRaw("Vertical") > 0)
        //{
        //    gameObject.transform.Translate(0, 0, thrustSpeed);
        //}

        //if(Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    gameObject.transform.Rotate(0, turnSpeed, 0);
        //}
        //else if(Input.GetAxisRaw("Horizontal") < 0)
        //{
        //    gameObject.transform.Rotate(0, -turnSpeed, 0);
        //}

        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire! " + rotation);

            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.x += 1.5f * Mathf.Cos(rotation * Mathf.PI / 180);
            spawnPos.z -= 1.5f * Mathf.Sin(rotation * Mathf.PI / 180);

            GameObject obj = Instantiate(bullet, spawnPos, Quaternion.identity) as GameObject;

            BulletScript b = obj.GetComponent<BulletScript>();

            Quaternion rot = Quaternion.Euler(new Vector3(0, rotation, 0));

            b.heading = rot;
        }
	}
}
