using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectChapterCanvas : MonoBehaviour {
    public Button startGame;
	// Use this for initialization
	void Start () {
		startGame.onClick.AddListener(Load_Scene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Load_Scene()
    {
        GameManager._gameCon.menuSelect.PlayOneShot(GameManager._gameCon.menuSelectvoice);
        SceneManager.LoadScene("Scene1-1");
    }
}
