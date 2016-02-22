using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class LevelButtonControl : MonoBehaviour {

	public LevelControl levelControl;
	public Text text;
	public int Level;
	
	void Update() {
		text.text = string.Format ("Level {0}:{1}", Mathf.Floor ((Level - 1) / 5) + 1, ((Level - 1) % 5));
		name = string.Format ("bt_{0}_{1}", Mathf.Floor ((Level - 1) / 5) + 1, ((Level - 1) % 5));
	}

	public void Click() {
		Application.LoadLevel (Level);
	}

	void OnMouseDown() {
		Click ();
	}
}
