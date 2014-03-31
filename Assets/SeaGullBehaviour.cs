using UnityEngine;
using System.Collections;

public class SeaGullBehaviour : MonoBehaviour {
	
	Vector3 force = Vector3.zero;
	Vector3 velocity = Vector3.zero;
	Vector3 target = Vector3.zero;
	
	public float maxSpeed = 25.0f;
	public float mass = 1.0f;
	
	// Use this for initialization
	void Start () {
		target = Random.insideUnitSphere * 10;
		target.x -= 220;
		target.y = 20;
		target.z += 330;
	}
	
	// Update is called once per frame
	void Update () {
		force += Seek ();
		
		Vector3 acceleration = force / mass;
		
		velocity += acceleration * Time.deltaTime;
		transform.position += velocity * Time.deltaTime;
		
		force = Vector3.zero;
		
		if (velocity.magnitude > float.Epsilon) {
			transform.forward = velocity.normalized;
		}
		
		velocity *= 0.99f;
		
		//Debug.DrawLine (transform.position, target, Color.black);
	}
	
	Vector3 Seek () {
		Vector3 desiredVelocity = target - transform.position;
		float distToTarget = desiredVelocity.magnitude;
		
		if (distToTarget < 2) {
			target = Random.insideUnitSphere * 10;
			target.x -= 220;
			target.y = 20;
			target.z += 330;
		}
		
		desiredVelocity.Normalize ();
		desiredVelocity *= maxSpeed;
		
		return desiredVelocity - velocity;
	}
	
	Vector3 ArriveToTarget() {
		Vector3 toTarget = target - transform.position;
		
		float distToTarget = toTarget.magnitude;
		float slowingDistance = 8.0f;
		
		if (distToTarget < 1) {
			target = Random.insideUnitSphere * 10;
		}
		
		float decelerationTweaker = maxSpeed / 5;
		float rampedSpeed = maxSpeed * (distToTarget / (slowingDistance * decelerationTweaker));
		
		float clampedSpeed = Mathf.Min (rampedSpeed, maxSpeed);
		
		Vector3 desiredVelocity = clampedSpeed * (toTarget / distToTarget);
		
		return desiredVelocity - velocity;
	}
}
