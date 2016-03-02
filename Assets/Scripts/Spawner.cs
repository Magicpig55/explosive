using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	GameObject Selected = null;
	Material SelectedMaterial = null;

	
	public GameObject[] SpawnedPrefabs;
	public Material HighlightMaterial;
	public int SpawnIndex = 0;

	void Update() {
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
			GameObject obj = hit.transform.gameObject;
			if(!(obj.CompareTag("CantSpawnOn") || obj.CompareTag("Interactable") || obj.CompareTag("GoalObject"))) {
				if(obj != Selected && obj != null) {
					if(Selected != null)
						Selected.GetComponent<MeshRenderer>().material = SelectedMaterial;
					Selected = obj;
					MeshRenderer mr = obj.GetComponent<MeshRenderer>();
					SelectedMaterial = mr.material;
					mr.material = HighlightMaterial;
				}
			} else {
				if(Selected != null) {
					Selected.GetComponent<MeshRenderer>().material = SelectedMaterial;
					SelectedMaterial = null;
					Selected = null;
				}
			}
		} else {
			if(Selected != null) {
				Selected.GetComponent<MeshRenderer>().material = SelectedMaterial;
				SelectedMaterial = null;
				Selected = null;
			}
		}
		if (Input.GetMouseButtonDown (0) && Selected != null) {
			Instantiate(SpawnedPrefabs[SpawnIndex], Selected.transform.position + (Vector3.up * 3), Selected.transform.rotation);
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			SelectRight();
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			SelectLeft();
		}
	}
	public void SelectLeft() {
		SpawnIndex--;
		if(SpawnIndex < 0)
			SpawnIndex = SpawnedPrefabs.Length - 1;
	}
	public void SelectRight() {
		SpawnIndex++;
		if(SpawnIndex >= SpawnedPrefabs.Length)
			SpawnIndex = 0;
	}
}
