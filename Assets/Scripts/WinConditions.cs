using UnityEngine;
using System.Collections;

public class WinConditions : MonoBehaviour {
	
	public Goal[] goals;
	public bool Won;

	// Update is called once per frame
	void Update () {
		bool win = true;
		foreach (Goal goal in goals) {
			if(!goal.ObjectInGoal)
				win = false;
		}
		if (win && goals.Length > 0 && Won != true) {
			Debug.Log ("Win!");
			Won = true;
		}
	}
}
