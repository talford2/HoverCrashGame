using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public float ForwardThrust = 2f;

	public float ForwardDrag = 0.5f;

	public float SteeringSpeed = 1f;

	private float currentSpeed = 0;

	public Collider PlayerCollider;

	public GameObject HitEffect;

	public List<Transform> CastTransforms;

	void Start()
	{
	}

	void Update()
	{
		//currentSpeed += Input.GetAxis("Vertical") * ForwardThrust * Time.deltaTime;
		currentSpeed += 10f * Input.GetAxis("Mouse ScrollWheel") * ForwardThrust * Time.deltaTime;

		var upDown = -Input.GetAxis("Vertical") * SteeringSpeed * Time.deltaTime;
		var leftRight = Input.GetAxis("Horizontal") * SteeringSpeed * Time.deltaTime;
		transform.forward += transform.right * leftRight + transform.up * upDown;

		//var direction = transform.forward;

		foreach (var trans in CastTransforms)
		{
			var r = new Ray(trans.position, trans.forward);
			RaycastHit hit;

			var distCheck = currentSpeed * 2.0f;

			// forward cast
			if (Physics.Raycast(r, out hit, distCheck))
			{
				Debug.Log("hit! " + hit.normal + "/" + transform.forward);

				currentSpeed *= 0.2f;

				transform.forward = Vector3.Reflect(trans.forward, hit.normal).normalized;

				// hit effect
				Instantiate(HitEffect, hit.point, Quaternion.identity);
			}
			// down cast
			//if (Physics.Raycast(new Ray(transform.position, Vector3.)))

			Debug.DrawRay(trans.position, trans.forward * 15, Color.red);
		}

		transform.Translate(currentSpeed * transform.forward, Space.World);
	}

	void FixedUpdate()
	{
	}


	private void OnCollisionEnter(Collision collision)
	{
		foreach (var hitPoint in collision.contacts)
		{
			Instantiate(HitEffect, hitPoint.point, Quaternion.identity);
		}
		//collision.contacts[0].point
		Debug.Log("CRASH!");
	}
}
