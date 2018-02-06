using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterHp : MonoBehaviour {
    float currentHp;
    public float MaxHp;
    Canvas myCanvas;
    Slider myHp;
    // Use this for initialization
    void Start()
    {
        GameManager._gameCon.maxHp.TryGetValue(GetComponent<Transform>().name, out MaxHp);
        currentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getDamaged(float damage)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        myHp = transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        currentHp -= damage;
        myHp.value = currentHp / MaxHp;
        if (currentHp < 0)
        {
            currentHp = 0;
            //播放死亡动画
            int moneyReward;
            GameManager._gameCon.reward.TryGetValue(GetComponent<Transform>().name, out moneyReward);
            GameManager._gameCon.moneyManager += moneyReward;
            Destroy(transform.gameObject);
        }
    }
    public bool IsDead()
    {
        if (currentHp == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
