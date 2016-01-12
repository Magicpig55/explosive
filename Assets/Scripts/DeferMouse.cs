using UnityEngine;
using System.Collections;

public class DeferMouse : MonoBehaviour {

	public Activatable TargetObject;

	void OnMouseDown() {
		TargetObject.Activate ();
	}
}
