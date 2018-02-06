using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BreakingObstacle : MonoBehaviour {
    float currentHp;
    public float MaxHp;
    Slider mySlider;
	// Use this for initialization
	void Start () {
        GameManager._gameCon.maxHp.TryGetValue(GetComponent<Transform>().name, out MaxHp);
        currentHp = MaxHp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void getDamaged(float damage)
    {
        transform.GetChild(1).gameObject.SetActive(true);
        mySlider = transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        currentHp -= damage;
        mySlider.value = currentHp / MaxHp;
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
}
