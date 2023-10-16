using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
	public CharacterController CC;
	public float MoveSpeed;
	public float Gravity = -9.8f;
	public float JumpSpeed;

	public float verticalSpeed;

	private void Update()
	{
		Vector3 movement = Vector3.zero;
		float forwardMovement = Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime;
		float sideMovement = Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime;
		movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

		if (CC.isGrounded)
		{
			verticalSpeed = 0f;
			if(Input.GetKeyDown(KeyCode.Space))
			{
				verticalSpeed = JumpSpeed;
			}
		}
		
		verticalSpeed += (Gravity * Time.deltaTime);
		movement += (transform.up * verticalSpeed * Time.deltaTime);

		CC.Move(movement);
	}
	private void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Respawn"){
			Debug.Log("kladjf");
			CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
			cc.enabled = false;
			transform.position = new Vector3(0f, 1f, 0f);
			cc.enabled = true;
		}
	}
}
