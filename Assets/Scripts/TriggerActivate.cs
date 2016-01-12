using UnityEngine;
using System.Collections;

public class TriggerActivate : MonoBehaviour {
	public Activatable[] objects;
	void OnTriggerEnter() {
		foreach (Activatable obj in objects) {
			obj.Activate ();
		}
	}
	void OnTriggerExit() {
		foreach (Activatable obj in objects) {
			obj.Deactivate ();
		}
	}
}
