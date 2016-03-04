using UnityEngine;
using System.Collections;
using System.Linq;
public class LevelControl : MonoBehaviour {

	public void ChangeLevel(string scene) {
		Application.LoadLevel (scene);
	}
	public void ChangeLevel(int scene) {
		Application.LoadLevel (scene);
	}
	public void Restart() {
		Application.LoadLevel (currentLevel);
		escapeMenuOpen = false;
		EscapeMenu.SetTrigger ("disable");
	}

	private int currentLevel = 0;
	private WinConditions win;
	private bool escapeMenuOpen = false;

	public Animator EscapeMenu;
	public Animator LevelMenu;
	public Animator MainMenu;
	public bool[] LevelComplete;

	public SpawnUI SpawnUI;

	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType(GetType()).Length > 1) {
			DestroyImmediate(gameObject);
		}
		if (currentLevel == 0) {
			MainMenu.SetTrigger ("enable");
			SpawnUI.Active = false;
		} else { 
			MainMenu.SetTrigger ("disable");
			SpawnUI.Active = true;
		}
	}
	void OnLevelWasLoaded(int level) {
		currentLevel = level;
		win = Camera.main.GetComponent<WinConditions>();
		EscapeMenu.SetTrigger ("disable");
		LevelMenu.SetTrigger ("disable");
		if (currentLevel == 0) {
			MainMenu.SetTrigger ("enable");
			SpawnUI.Active = false;
		} else { 
			MainMenu.SetTrigger ("disable");
			SpawnUI.Active = true;
		}
		escapeMenuOpen = false;
	}
	void Update() {
		if (win != null) {
			if (win.Won) {
				if(currentLevel < LevelComplete.Length - 1) {
					LevelComplete[currentLevel + 1] = true;
					Application.LoadLevel (currentLevel + 1);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape) && currentLevel != 0) {
			if(escapeMenuOpen)
				EscapeMenu.SetTrigger("disable");
			else 
				EscapeMenu.SetTrigger("enable");
			escapeMenuOpen =! escapeMenuOpen;
			Debug.Log("Oh boy!");
		}
	}
}
