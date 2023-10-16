using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCameraHandler : MonoBehaviour
{
	public float MouseSensitivity;
	public Transform CamTransform;
	private float camRotation = 0f;
	private GameObject breakableWall;
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		camRotation -= Input.GetAxis("Mouse Y") * MouseSensitivity;
		camRotation = Mathf.Clamp(camRotation, -90f, 90f);
		CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));
		transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, Input.GetAxis("Mouse X") * MouseSensitivity, 0f));
		if(Input.GetMouseButtonDown(0)){
			RaycastHit rayHit;
			if (Physics.Raycast(CamTransform.position, CamTransform.forward, out rayHit)){
				if(rayHit.collider.gameObject.tag == "Target" && rayHit.distance <= 10f){
					Debug.Log("target hit");
					Destroy(rayHit.collider.gameObject);
				}
			}
		}
	}
}