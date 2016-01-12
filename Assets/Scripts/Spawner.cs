using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	GameObject Selected = null;
	Shader SelectedShader = null;

	
	public GameObject[] SpawnedPrefabs;
	public Shader HighlightShader;
	public int SpawnIndex = 0;


	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
			GameObject obj = hit.transform.gameObject;
			if(!(obj.CompareTag("CantSpawnOn") || obj.CompareTag("Interactable") || obj.CompareTag("GoalObject"))) {
				if(obj != Selected && obj != null) {
					Selected = obj;
					MeshRenderer mr = obj.GetComponent<MeshRenderer>();
					SelectedShader = mr.material.shader;
					mr.material.shader = HighlightShader;
				}
			} else {
				Selected.GetComponent<MeshRenderer>().material.shader = SelectedShader;
				SelectedShader = null;
				Selected = null;
			}
		} else {
			Selected.GetComponent<MeshRenderer>().material.shader = SelectedShader;
			SelectedShader = null;
			Selected = null;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			SpawnIndex++;
			if(SpawnIndex >= SpawnedPrefabs.Length)
				SpawnIndex = 0;
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			SpawnIndex--;
			if(SpawnIndex < 0)
				SpawnIndex = SpawnedPrefabs.Length - 1;
		}
	}
}
