using UnityEngine;
using System.Collections;

public class DustballController : MonoBehaviour {
	public float rotationSpeed = -800;
	public GameObject particles;

	void Start() {
	}

	// Use this for initialization
	void FixedUpdate() {
		rigidbody2D.angularVelocity = rotationSpeed;
	}

	void Update() {
		particles.particleSystem.Emit(1);
	}

	void OnTriggerEnter(Collider2D other) {
		Destroy (other.gameObject);

	}
}
