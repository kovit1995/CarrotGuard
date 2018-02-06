using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MonsterCondition : MonoBehaviour {
    DOTweenPath myPath;
    public int slowedLevel;
    public bool isSlowedLV1;
    public bool isSlowedLV2;
    public bool isSlowedLV3;
    bool coroutineActivated;
	// Use this for initialization
    IEnumerator Healed()
    {
        myPath.GetTween().timeScale = myPath.GetTween().timeScale - 0.25f * slowedLevel;
        yield return new WaitForSeconds(3f);
        slowedLevel = 0;
        isSlowedLV1 = false;
        isSlowedLV2 = false;
        isSlowedLV3 = false;
        myPath.GetTween().timeScale = myPath.GetTween().timeScale + 0.25f * slowedLevel;
    }
	void Start () {
        myPath = GetComponent<DOTweenPath>();
        isSlowedLV1 = false;
        isSlowedLV2 = false;
        isSlowedLV3 = false;
        slowedLevel = 0;
        coroutineActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (slowedLevel == 1)
        {
            isSlowedLV1 = true;
            isSlowedLV2 = false;
            isSlowedLV3 = false;
        }
        if (slowedLevel == 2)
        {
            isSlowedLV1 = false;
            isSlowedLV2 = true;
            isSlowedLV3 = false;
        }
        if (slowedLevel == 3)
        {
            isSlowedLV1 = false;
            isSlowedLV2 = false;
            isSlowedLV3 = true;
        }
        if (!coroutineActivated)
        {
            if (isSlowedLV3)
            {
                StartCoroutine("Healed");
                coroutineActivated = true;
            }
            else if (isSlowedLV2)
            {

                StartCoroutine("Healed");
                coroutineActivated = true;
            }
            else if (isSlowedLV1)
            {

                StartCoroutine("Healed");
                coroutineActivated = true;
            }
        }
        if(Vector3.Distance(transform.position,myPath.wps[myPath.wps.Count-1])<=0.01f)
        {
            GameManager._gameCon.playerHp--;
            Destroy(transform.gameObject);//到达寻路点销毁自身
        }
	}
}
