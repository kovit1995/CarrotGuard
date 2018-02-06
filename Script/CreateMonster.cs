using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateMonster : MonoBehaviour {
    public GameObject[] monsters;
    public GameObject boss;
    public Transform createPoint;
    Animator createMonster;
    int created_Number;
    int monster_Index;
    float timer;
	// Use this for initialization
	void Start () {
        timer = 0;
        created_Number = 0;
        monster_Index = 0;
        createMonster = GetComponent<Animator>();
	}
    IEnumerator Create_Monster()
    {
        while (true)
        {
            createMonster.SetBool("IsCreating", true);
            Create_Monsters_Function(monster_Index);
            yield return new WaitForSeconds(0.8f);
            createMonster.SetBool("IsCreating", false);
            yield return new WaitForSeconds(0.2f);
        }
    }
	// Update is called once per frame
	void Update () {
        Waves();
	}
    void Waves()
    {
        if (GameManager._gameCon.waveNumber == 0)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)//延时5秒开启协程
            {
                timer = 0;
                GameManager._gameCon.waveNumber = 1;
                StartCoroutine("Create_Monster");
            }
        }
        if (GameManager._gameCon.waveNumber == 1)
        {
            if (created_Number == 5)
            {
                StopCoroutine("Create_Monster");
                createMonster.SetBool("IsCreating", false);
                //print(timer);
                if (GameManager._gameCon.presentMonsterNumber == 0)//若怪物全部死亡则准备下一波
                {
                    timer += Time.deltaTime;
                    if (timer > 5f)//延时5秒生成下一波怪物
                    {
                        created_Number = 0;
                        timer = 0;
                        GameManager._gameCon.waveNumber++;
                        StartCoroutine("Create_Monster");
                    }
                }
            }
        }
        if (GameManager._gameCon.waveNumber == 2)
        {
            if (created_Number == 5)
            {
                StopCoroutine("Create_Monster");
                createMonster.SetBool("IsCreating", false);
                //print(timer);
                if (GameManager._gameCon.presentMonsterNumber == 0)//若怪物全部死亡则准备下一波
                {
                    timer += Time.deltaTime;
                    if (timer > 5f)//延时5秒生成下一波怪物
                    {
                        created_Number = 0;
                        timer = 0;
                        GameManager._gameCon.waveNumber++;
                        monster_Index = 1;
                        StartCoroutine("Create_Monster");
                    }
                }
            }
        }
        if (GameManager._gameCon.waveNumber == 3)
        {
            Monster_Creater(7);
        }
        if (GameManager._gameCon.waveNumber == 4)
        {
            Monster_Creater(7);
        }
        if (GameManager._gameCon.waveNumber == 5)
        {
            Monster_Creater(9);
        }
        if (GameManager._gameCon.waveNumber == 6)
        {
            Monster_Creater(9);
        }
        if (GameManager._gameCon.waveNumber == 7)
        {
            Monster_Creater(11);
        }
        if (GameManager._gameCon.waveNumber == 8)
        {
            Monster_Creater(11);
        }
        if (GameManager._gameCon.waveNumber == 9)
        {
            Monster_Creater(13);
        }
        if (GameManager._gameCon.waveNumber == 10)
        {
            Monster_Creater(13);
        }
        if (GameManager._gameCon.waveNumber == 11)
        {
            Monster_Creater(15);
        }
        if (GameManager._gameCon.waveNumber == 12)
        {
            Monster_Creater(15);
        }
        if (GameManager._gameCon.waveNumber == 13)
        {
            Monster_Creater(15);
        }
        if (GameManager._gameCon.waveNumber == 14)
        {
            if (created_Number == 15)
            {
                StopCoroutine("Create_Monster");
                createMonster.SetBool("IsCreating", false);
                //print(timer);
                if (GameManager._gameCon.presentMonsterNumber == 0)//BOSS关
                {
                    timer += Time.deltaTime;
                    if (timer > 5f)//延时5秒生成BOSS
                    {
                        created_Number = 0;
                        timer = 0;
                        GameManager._gameCon.waveNumber++;
                        Create_Boss_Function();
                    }
                }
            }
        }
        if (GameManager._gameCon.waveNumber == 15)
        {
            if (created_Number == 1)
            {
                if (GameManager._gameCon.presentMonsterNumber == 0)
                {
                    timer += Time.deltaTime;
                    if (timer > 3f)//延时3秒结束游戏
                    {
                        created_Number = 0;
                        timer = 0;
                        SceneManager.LoadScene("End");
                    }
                }
            }
        }
    }
    void Monster_Creater(int cn)
    {
        if (created_Number == cn)
        {
            StopCoroutine("Create_Monster");
            createMonster.SetBool("IsCreating", false);
            //print(timer);
            if (GameManager._gameCon.presentMonsterNumber==0)//若怪物全部死亡则准备下一波
            {
                timer += Time.deltaTime;
                if (timer > 5f)//延时5秒生成下一波怪物
                {
                    created_Number = 0;
                    timer = 0;
                    GameManager._gameCon.waveNumber++;
                    StartCoroutine("Create_Monster");
                }
            }
        }
    }
    void Create_Monsters_Function(int i)
    {
        Instantiate(monsters[i], createPoint.position, monsters[i].transform.rotation);
        created_Number++;
    }
    void Create_Boss_Function()
    {
        Instantiate(boss, createPoint.position, boss.transform.rotation);
        created_Number++;
    }
}
