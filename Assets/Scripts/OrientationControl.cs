using UnityEngine;
using System.Collections;

public class OrientationControl : MonoBehaviour {

	public bool Continuous;

    float CurrentRotation;
    float TargetRotation;
	
	// Update is called once per frame
	void Update () {
		if (!Continuous) {
			if (Input.GetKeyDown (KeyCode.LeftArrow))
				TargetRotation += 45;
			if (Input.GetKeyDown (KeyCode.RightArrow))
				TargetRotation -= 45;
		}
	}

    void FixedUpdate() {
		if (!Continuous)
			CurrentRotation = (CurrentRotation + TargetRotation) / 1.5f;
		else
			CurrentRotation += 0.25f;
        transform.eulerAngles = new Vector3(0, CurrentRotation, 0);
    }
}
