using UnityEngine;
using System.Collections;

public class CameraInputController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)) {
            GetComponent<FreeFlyCamera>().Active = !GetComponent<FreeFlyCamera>().Active;
            GetComponent<SimpleSmoothMouseLook>().Active = !GetComponent<SimpleSmoothMouseLook>().Active;
        }
	}
}
