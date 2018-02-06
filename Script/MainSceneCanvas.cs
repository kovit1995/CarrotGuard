using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainSceneCanvas : MonoBehaviour {
	// Use this for initialization
    public Button adventureMode;
	void Start () {
        adventureMode.onClick.AddListener(Load_AdventureMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Load_AdventureMode()
    {
        GameManager._gameCon.menuSelect.PlayOneShot(GameManager._gameCon.menuSelectvoice);
        SceneManager.LoadScene("SelectScene");
    }
}
