using UnityEngine;
using System.Collections;

public class scrollingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float scrollSpeed =1;
	public float scrollSpeed2 =1;

	// Update is called once per frame
	void Update () {
		float offset = Time.time * scrollSpeed;

		float offset2 = Time.time * scrollSpeed2;

		renderer.material.mainTextureOffset = new Vector2 (offset2, -offset);

	}
}
