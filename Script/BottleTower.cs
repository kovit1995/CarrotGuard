using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleTower : MonoBehaviour {
    float attack;
    float speed;
    public int price;
    public int sell;
    List<GameObject> targetsMonster;
    List<GameObject> targetsObstacle;
    int targetNumber;
    public bool coroutineActived;
    Collider2D[] myColliders;
    Collider2D targetCollider;
    bool isTarget;
    Vector3 mousPosition;
    Animator bottleAttack;
	// Use this for initialization
	void Start () {
        targetsMonster = new List<GameObject>();
        targetsObstacle = new List<GameObject>();
        targetNumber = 0;
        coroutineActived = false;
        isTarget = false;
        bottleAttack = GetComponent<Animator>();
        if (transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 0)
        {
            //print("调用LV0构造函数");
        }
        if (transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 1)
        {
            //print("调用LV1构造函数");
            attack = 50f;//攻击力为50
            speed = 0.8f;//射速为0.8秒1次
            price = 100;//造价为100金币
            sell = 80;
            transform.GetComponent<CircleCollider2D>().radius = 1f;//攻击半径为1
            GameManager._gameCon.moneyManager -= price;
        }
        if (transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 2)
        {
            //print("调用LV2构造函数");
            attack = 100f;
            speed = 0.8f;
            price = 180;
            sell = 224;
            transform.GetComponent<CircleCollider2D>().radius = 1.2f;
            GameManager._gameCon.moneyManager -= price;
        }
        if (transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 3)
        {
            //print("调用LV3构造函数");
            attack = 200f;
            speed = 0.8f;
            price = 260;
            sell = 432;
            transform.GetComponent<CircleCollider2D>().radius = 1.5f;
            GameManager._gameCon.moneyManager -= price;
        }

	}
    IEnumerator AttackTarget()
    {
        bottleAttack.SetBool("IsShooting", true);
        coroutineActived = true;
        //按照一定射速进行攻击
        while (true)
        {
            Attack();
            yield return new WaitForSeconds(speed);
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            mousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            myColliders = Physics2D.OverlapCircleAll(mousPosition, 0f);//获得点击位置的触发器列表
            foreach (Collider2D temp in myColliders)
            {
                if (temp.tag == "Obstacle")
                {
                    if (isTarget)
                    {
                        targetCollider.transform.GetChild(0).gameObject.SetActive(false);
                        targetCollider = null;
                        isTarget = false;
                    }
                    else
                    {
                        targetCollider = temp;
                        targetCollider.transform.GetChild(0).gameObject.SetActive(true);
                        isTarget = true;
                    }
                }
            }
        }
        if (!isTarget)//判断是否已标记目标
        {
            if (targetsMonster.Count != 0)//判断是否有目标进入攻击范围
            {
                if (targetsMonster[targetNumber] != null)//若目标已被销毁，则从列表中移除
                {
                    if (coroutineActived == false)//判断攻击协程是否已经开启
                    {
                        StartCoroutine("AttackTarget");
                    }
                    transform.up = (targetsMonster[targetNumber].transform.position - transform.position).normalized;
                }
                else
                {
                    targetsMonster.Remove(targetsMonster[targetNumber]);
                }
            }
            else//若没有目标，则停止攻击协程
            {
                StopCoroutine("AttackTarget");
                coroutineActived = false;
                bottleAttack.SetBool("IsShooting", false);
            }
        }
        else
        {
            if (targetsObstacle.Count != 0)//判断是否有目标进入攻击范围
            {
                if (targetsObstacle[targetNumber] != null)//若目标已被销毁，则从列表中移除
                {
                    if (coroutineActived == false)//判断攻击协程是否已经开启
                    {
                        StartCoroutine("AttackTarget");
                    }
                    transform.up = (targetsObstacle[targetNumber].transform.position - transform.position).normalized;
                }
                else
                {
                    targetsObstacle.Remove(targetsObstacle[targetNumber]);
                    isTarget = false;
                }
            }
            else//若没有目标，则停止攻击协程
            {
                StopCoroutine("AttackTarget");
                coroutineActived = false;
                bottleAttack.SetBool("IsShooting", false);
                isTarget = false;
            }
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        //print("进入");
        if (other.transform.tag == "Monster")
        {
            targetsMonster.Add(other.gameObject);
        }
        if (other.transform.tag == "Obstacle")
        {
            targetsObstacle.Add(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //print("离开");
        if (other.transform.tag == "Monster")
        {
            targetsMonster.Remove(other.gameObject);
        }
        if (other.transform.tag == "Obstacle")
        {
            targetsObstacle.Remove(other.gameObject);
        }
    }
    void Attack()
    {
        if (isTarget)
        {
            if (targetsObstacle[targetNumber] != null)
            {
                targetsObstacle[targetNumber].GetComponent<BreakingObstacle>().getDamaged(attack);
            }
            else
            {
                targetsObstacle.Remove(targetsObstacle[targetNumber]);
            }
        }
        else
        {
            if (targetsMonster[targetNumber] != null)
            {
                targetsMonster[targetNumber].GetComponent<MonsterHp>().getDamaged(attack);
            }
            else
            {
                targetsMonster.Remove(targetsMonster[targetNumber]);
            }
        }
    }
}
