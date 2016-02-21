using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public string playerName;
	public float speed = 2.5f;
	public float maxVelocity = 3f;
    private Transform player;

	// Use this for initialization
	void Start () {
	    player = GameObject.Find("/Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt(player.position);

		Rigidbody rb = GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * speed);

		if (rb.velocity.magnitude > maxVelocity)
		{
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
		}
	}
}
