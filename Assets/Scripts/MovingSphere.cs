using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
	[SerializeField, Range(0f, 100f)]
	float maxSpeed = 10f;
	[SerializeField, Range(0f, 100f)]
	float maxAcceleration = 10f;
	Vector3 velocity;

	void Update()
	{
		Vector2 playerInput;
		playerInput.x = Input.GetAxis("Horizontal");
		playerInput.y = Input.GetAxis("Vertical");


		Vector3 desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed; //Desired Velocity is the max velocity we want the b all to be able to reach
		float maxSpeedChange = maxAcceleration * Time.deltaTime; //Max Speed Change puts a limit on the speed increase based on the user defined Max Acceleration
		velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange); //moves velocity.x towards desiredVelocity.x by adding MaxSpeedChange 
		velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

		Vector3 displacement = velocity * Time.deltaTime; //Displacement takes the velocity and multiplies it by Delta Time, this is how much the ball will move in the next frame

		Vector3 newPosition = transform.localPosition + displacement; // New position is gotten from the balls current position + the displacement vector

		transform.localPosition = newPosition;
	}
}