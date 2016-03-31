using UnityEngine;
using System.Collections;
using System.Linq;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif
public class LevelControl : MonoBehaviour {

	public void ChangeLevel(string scene) {
#if UNITY_5_3
        SceneManager.LoadScene(scene);
#else
        Application.LoadLevel (scene);
#endif
    }
    public void ChangeLevel(int scene) {
#if UNITY_5_3
        SceneManager.LoadScene(scene);
#else
        Application.LoadLevel (scene);
#endif
    }
    public void Restart() {
#if UNITY_5_3
        SceneManager.LoadScene(currentLevel);
        Debug.Log("Using Unity 5.3");
#else
        Application.LoadLevel (currentLevel);
        Debug.Log("Using older version of Unity");
#endif
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

	public bool DisregardLevelComplete;

	void Awake() {
		Debug.Log ("LevelControl checking for other instances");
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Debug.Log ("LevelControl found other instance, destroying...");
			DestroyImmediate (gameObject);
		} else {
			Debug.Log ("No other instances found, continuing...");
			if (currentLevel == 0) {
				MainMenu.SetTrigger ("enable");
				SpawnUI.Active = false;
			} else { 
				MainMenu.SetTrigger ("disable");
				SpawnUI.Active = true;
			}
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
				Debug.Log(string.Format("Level {0} of {1}", currentLevel, LevelComplete.Length));
				if(currentLevel < LevelComplete.Length + 1) {
					LevelComplete[currentLevel - 1] = true;
					if(currentLevel == LevelComplete.Length) {
						ChangeLevel (0);
					} else {
                    	ChangeLevel (currentLevel + 1);
					}
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
