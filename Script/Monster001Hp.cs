using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster001Hp : MonoBehaviour {
    float currentHp;
    float MaxHp = 100;
    // Use this for initialization
    void Start()
    {
        currentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getDamaged(float damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
        {
            currentHp = 0;
            //播放死亡动画
            //Destroy(transform.gameObject);
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
