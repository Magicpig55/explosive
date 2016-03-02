using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnUI : MonoBehaviour {

	private Spawner spawner;
	private Text text;
	private string[] SpawnNames = {"Cube", "Sphere"};

	void Start() {
		spawner = Camera.main.GetComponent<Spawner> ();
		text = GetComponentInChildren<Text> ();
	}
	void Update() {
		text.text = SpawnNames [spawner.SpawnIndex];
	}

	public void GoLeft() {
		spawner.SelectLeft ();
	}
	public void GoRight() {
		spawner.SelectRight ();
	}
}
