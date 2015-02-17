using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public GameObject target;
	public float cameraSpeed = 7f;

	void FixedUpdate() {
		float x = Mathf.Max (target.transform.position.x, transform.position.x + cameraSpeed * Time.fixedDeltaTime);
		transform.position = new Vector3(x, transform.position.y, transform.position.z);
	}
}
