using UnityEngine;
using System.Collections;

public class PhysicsObject : MonoBehaviour {
	
	public AudioClip HitSound;
	
	void OnCollisionEnter(Collision col) {
		Collide ();
	}

	public void Collide() {
		AudioSource audio = GetComponent<AudioSource>();
		audio.pitch = Random.Range(.75f, 1.25f);
		audio.PlayOneShot(HitSound);
	}

	void Update() {
		if (transform.position.y < -50)
			Destroy (this.gameObject, 1);
	}
}
