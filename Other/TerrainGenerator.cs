using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {
	public GameObject terrainBlock;
	public float blockSize = 1;

	private Vector2 camLL;
	private Vector2 camUR;
	private Vector2 blockPos;

	// Use this for initialization
	void Start () {
		blockPos = new Vector2(-1, -1);
	}
	
	// Update is called once per frame
	void Update () {
		camLL = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10));
		camUR = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));
		//Add base level of blocks

		while (blockPos.x < camUR.x) {
						blockPos.x += blockSize;
						Instantiate (terrainBlock, blockPos, Quaternion.identity);
				}
		//Add levels
		for (int i = 1; i < (2)/*playerJumpSkill*/; i++)
		{
						blockPos.x = transform.position.x;
						blockPos.y = blockPos.y + i*(blockSize);
						while (blockPos.x < camUR.x)
						{
								if ((Random.Range (1, 100)) < 25) //25% /*player punch skill?*/
								{
										Instantiate (terrainBlock, blockPos, Quaternion.identity);
								}
								
								blockPos.x += blockSize;
						}
		}

			//			float n = Mathf.PerlinNoise(blockPos.x, blockPos.y);
			//			print (n);
			//			float nBlocks = (10f * n);
			//			for(int i = 0; i < nBlocks; ++i)
			//				Instantiate(terrainBlock, new Vector2(blockPos.x, blockPos.y + i * blockSize), Quaternion.identity);

	}
}