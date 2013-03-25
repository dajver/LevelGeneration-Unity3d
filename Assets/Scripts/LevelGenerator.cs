using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public Transform[] tilePrefabs;
	public int sections;

	void Start() {
		GenerateLevel();
	}

	public void GenerateLevel() {
		Transform currentTile = null;
		Transform previousTile = null;

		for(int i = 0; i < sections; i++) {
			currentTile = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length)], transform.position, Quaternion.identity) as Transform;

			if(previousTile) {
				Transform offset = previousTile.Find("End");

				if(offset) {
					currentTile.rotation = offset.rotation;
					currentTile.position += offset.position - currentTile.Find("Start").position;
				}
			}

			previousTile = currentTile;
		}
	}
}
