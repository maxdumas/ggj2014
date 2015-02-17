using UnityEngine;
using System.Collections;

public class GarbageCollection : MonoBehaviour {
	
	private bool hasAppeared;
	
	// Use this for initialization
	void Start () {
		hasAppeared = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<SpriteRenderer>().isVisible) {
			hasAppeared = true;
		}
		if (hasAppeared) {
			if (!renderer.isVisible) {
				Destroy(gameObject);
			}
			
		}
	}
	
}