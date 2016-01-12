using UnityEngine;
using System.Collections;

public class Pusher : Activatable {
	
	Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	void OnMouseDown () {
		Activate ();
	}

	public override void Activate() {
		animator.SetBool ("Rare", Random.value < .5);
		animator.SetTrigger ("Activate");
	}

	public override void Deactivate() {
		animator.SetBool ("Rare", Random.value < .5);
		animator.SetTrigger ("Deactivate");
	}
}
