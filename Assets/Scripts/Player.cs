using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float ForwardThrust = 2f;

	public float ForwardDrag = 0.5f;

	public float TurnSpeed = 1f;

	private float currentSpeed = 0;

	public Collider PlayerCollider;

	public GameObject HitEffect;

	void Start()
	{
	}

	void Update()
	{
		currentSpeed += Input.GetAxis("Vertical") * ForwardThrust * Time.deltaTime;
		var direction = transform.forward;

		Ray r = new Ray(transform.position, direction);
		RaycastHit hit;

		Debug.DrawRay(transform.position, direction * 15, Color.red);

		var distCheck = currentSpeed * 2.0f;

		// forward cast
		if (Physics.Raycast(r, out hit, distCheck))
		{
			Debug.Log("hit! " + hit.normal + "/" + transform.forward);

			currentSpeed -= Time.deltaTime * 100;
			direction = Vector3.Reflect(transform.forward, hit.normal).normalized;

			// hit effect
			Instantiate(HitEffect, hit.point, Quaternion.identity);
		}
		// down cast
		//if (Physics.Raycast(new Ray(transform.position, Vector3.)))

		transform.forward = direction;

		transform.Translate(currentSpeed * direction);
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
