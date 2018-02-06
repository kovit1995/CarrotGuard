using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public int waveNumber;
    public int presentMonsterNumber = 0;
    public Dictionary<string, float> maxHp = new Dictionary<string, float>();
    public Dictionary<string, int> reward = new Dictionary<string, int>();
    public int moneyManager;
    public int playerHp;
    public AudioSource mySource;
    public AudioSource menuSelect;
    public AudioClip menuSelectvoice;
    private static GameManager gameCon;
    public static GameManager _gameCon
    {
        get
        {
            if (gameCon == null)
            {
                gameCon = GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            return gameCon;
        }
    }
	// Use this for initialization
	void Start ()
    {
        #region//怪物信息载入 
        maxHp.Add("Monster001(Clone)", 100);
        reward.Add("Monster001(Clone)", 14);
        maxHp.Add("Monster002(Clone)", 120);
        reward.Add("Monster002(Clone)", 14);
        maxHp.Add("Boss001(Clone)", 500);
        reward.Add("Boss001(Clone)", 100);
        #endregion
        #region//障碍信息载入
        maxHp.Add("Cloud", 800);
        reward.Add("Cloud", 100);
        maxHp.Add("Rainbow", 1400);
        reward.Add("Rainbow", 200);
        #endregion
        mySource = GetComponent<AudioSource>();
        menuSelect = GameObject.Find("MenuSelect").GetComponent<AudioSource>();
        menuSelectvoice = menuSelect.clip;
        if (gameCon != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(_gameCon.gameObject);
	}
	void OnApplicationQuit()
    {
        gameCon = null;
    }
	// Update is called once per frame
	void Update () {
        //print(playerHp);
        presentMonsterNumber = GameObject.FindGameObjectsWithTag("Monster").Length;
        if (!mySource.isPlaying && SceneManager.GetActiveScene().name == "MainScene1")
        {
            mySource.Play();
            mySource.loop = true;
        }
        if (mySource.isPlaying && SceneManager.GetActiveScene().name == "Scene1-1")
        {
            mySource.Stop();
        }
        if (SceneManager.GetActiveScene().name == "Scene1-1" && playerHp <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
	}
}
