using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {
	// Use this for initialization
    Text moneyText;
	void Start () {
        moneyText = GameObject.Find("MoneyManager").GetComponent<Text>();
        string activatedSceneName = SceneManager.GetActiveScene().name;
        if (activatedSceneName == "Scene1-1")
        {
            GameManager._gameCon.moneyManager = 260;
            GameManager._gameCon.playerHp = 10;
        }
    }
	
	// Update is called once per frame
	void Update () {
        moneyText.text = GameManager._gameCon.moneyManager.ToString();
        if (GameManager._gameCon.playerHp <= 0)
        {
            //游戏失败
        }
	}
}
