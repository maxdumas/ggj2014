using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {
	public GameObject terrainBlock;
	public GameObject[] cacti;
	public float blockSize = 1;
	private Vector2 camUR;
	private Vector2 blockPos;
	private GameObject player;

	private static float terrainSeed = Random.value;
	// Use this for initialization
	void Start () {
		blockPos = new Vector2(-6 * blockSize, -1);
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		int jumpScore =(int) player.GetComponent<PlayerController>().jumpScore;
		int kickScore =(int) player.GetComponent<PlayerController>().kickScore;

		int heightFactor = 4;
		if (kickScore>jumpScore) heightFactor =2;

		int cactiFactor =1;
		if (kickScore>jumpScore) cactiFactor =3;

		camUR = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));
		
		while(blockPos.x <= camUR.x + 2 * blockSize) {
			float nBlocks = 1;
			if(blockPos.x > 12) nBlocks = (heightFactor * Mathf.PerlinNoise(blockPos.x / 14f, terrainSeed));

			for(int i = 0; i < nBlocks; ++i) {
				blockPos.y = i * blockSize;
				Instantiate(terrainBlock, blockPos, Quaternion.identity);
			}
			if((int)blockPos.x % 10 == 0 && Random.Range(0,3)<=cactiFactor) {
				blockPos.y += blockSize;
				Instantiate(cacti[Random.Range(0, cacti.Length)], blockPos, Quaternion.identity);
			}
			blockPos.x += blockSize;
		}
	}
}