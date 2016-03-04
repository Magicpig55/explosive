using UnityEngine;
using System.Collections;

public class Launcher : Activatable {

	Animator animator;
	bool Activated = false;
	public float HForce;
	public float VForce;
	Rigidbody localBody = null;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	public override void Activate() {
		animator.SetTrigger("Activate");
		Activated = !Activated;
		if (Activated) {
			localBody.velocity = new Vector3(0, 0, 0);
			localBody.AddForce ((transform.up * VForce) + (transform.forward * HForce));
		}
	}

	public override void Deactivate() {
		animator.SetTrigger("Deactivate");
		Activated = false;
	}

	void OnMouseDown () {
		Activate ();
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position + (transform.up), transform.TransformVector(new Vector3(0, VForce, HForce).normalized));
	}

	void OnTriggerEnter(Collider other) {
		Rigidbody rb = other.gameObject.GetComponent<Rigidbody> ();
		other.gameObject.GetComponent<PhysicsObject>().Collide ();
		localBody = rb;
	}
	void OnTriggerExit(Collider other) {
		localBody = null;
	}
}
