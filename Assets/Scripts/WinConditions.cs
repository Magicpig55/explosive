using UnityEngine;
using System.Collections;

public class WinConditions : MonoBehaviour {
	
	public Goal[] goals;

	// Update is called once per frame
	void Update () {
		bool win = true;
		foreach (Goal goal in goals) {
			if(!goal.ObjectInGoal)
				win = false;
		}
		if (win && goals.Length > 0)
			Debug.Log ("Win!");
	}
}
