using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnUI : MonoBehaviour {

	private Spawner spawner;
	private Text text;
	private string[] SpawnNames = {"Cube", "Sphere"};

	private bool _active = false;
	public bool Active {
		get {
			return _active;
		}
		set {
			_active = value;
			this.gameObject.SetActive(value);
		}
	}
	
	void Start() {
		spawner = Camera.main.GetComponent<Spawner> ();
		text = GetComponentInChildren<Text> ();
	}
	void OnLevelWasLoaded() {
		spawner = Camera.main.GetComponent<Spawner> ();
	}
	void Update() {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			GoLeft();
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			GoRight();
		}
		text.text = SpawnNames [spawner.SpawnIndex];
	}

	public void GoLeft() {
		spawner.SelectLeft ();
	}
	public void GoRight() {
		spawner.SelectRight ();
	}
}
