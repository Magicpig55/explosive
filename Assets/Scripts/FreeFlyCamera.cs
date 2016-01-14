using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera/Free Fly Camera")]
public class FreeFlyCamera : MonoBehaviour {

    public float Speed = 0.3f;
    public bool Active = true;

	// Update is called once per frame
	void Update () {
	    if (Input.GetAxis("Vertical") != 0) {
            transform.Translate(Vector3.forward * Speed * Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Translate(Vector3.right * Speed * Input.GetAxis("Horizontal"));
        }
    }
}
