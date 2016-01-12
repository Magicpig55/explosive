using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public bool ObjectInGoal = false;

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.CompareTag("GoalObject"))
			ObjectInGoal = true;
	}
}
