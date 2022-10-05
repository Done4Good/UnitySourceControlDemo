using System.Collections;using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5;
	public float xdir, zdir;
	private Rigidbody rgbd;
	public Animator anim;


	public float jumpForce = 0.5f;
	public Transform groundCheck;
	public LayerMask groundMask;
	public float gravity = -9.81f;
	public float groundDistance = 0.2f;

	private Vector3 velocity;
	public bool isGrounded;

	// Use this for initialization
	void Awake () {
		rgbd = gameObject.GetComponent<Rigidbody>();
		anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if (isGrounded && velocity.y <= 0.2f)
		{
			velocity.y = 0f;		
						
		}

		
		
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = jumpForce;
		} 
			
		velocity.y += gravity * Time.deltaTime;


		//move w,a,s,d
		xdir = Input.GetAxis("Horizontal");
		zdir = Input.GetAxis("Vertical");

		if (isGrounded)
		{
			rgbd.velocity = new Vector3(xdir, 0f, zdir) * speed;
		} 
		
		rgbd.velocity = new Vector3(xdir, velocity.y, zdir) * speed;


		//Debug.Log(Vector3.Normalize(rgbd.velocity));



		anim.SetFloat("Speed", Vector3.Magnitude(Vector3.Normalize(rgbd.velocity)));

	}
}
