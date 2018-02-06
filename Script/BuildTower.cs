using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour {
	// Use this for initialization
    RaycastHit2D[] myHits;
    Collider2D[] myColliders;
    Collider2D buildPointCollider;
    Vector3 mousPosition;
    bool buildListIsActivated;
    bool upgradeListIsActivated;
    bool bottleTowerIsActivated;
    bool shitTowerIsActivated;
    bool upgradeTowerToLV2IsActivated;
    bool upgradeTowerToLV3IsActivated;
    public GameObject tempParent;
    GameObject BuildPointPrefab;
    AudioSource towerSelect;
    AudioSource towerSelectCancel;
    AudioSource towerBuild;
    AudioSource towerUpgrade;
    AudioSource towerSell;
    AudioClip towerSelectClip;
    AudioClip towerSelectCancelClip;
    AudioClip towerBuildClip;
    AudioClip towerUpgradeClip;
    AudioClip towerSellClip;
	void Start () {
        //Physics2D 
        buildListIsActivated = false;
        upgradeListIsActivated = false;
        bottleTowerIsActivated = false;
        shitTowerIsActivated = false;
        upgradeTowerToLV2IsActivated = false;
        upgradeTowerToLV3IsActivated = false;
        BuildPointPrefab = GameObject.FindGameObjectWithTag("BuildPoint");
        towerSelect = GameObject.Find("TowerSelect").GetComponent<AudioSource>();
        towerSelectClip = towerSelect.clip;
        towerSelectCancel = GameObject.Find("TowerSelectCancel").GetComponent<AudioSource>();
        towerSelectCancelClip = towerSelectCancel.clip;
        towerBuild = GameObject.Find("TowerBuild").GetComponent<AudioSource>();
        towerBuildClip = towerBuild.clip;
        towerUpgrade = GameObject.Find("TowerUpgrade").GetComponent<AudioSource>();
        towerUpgradeClip = towerUpgrade.clip;
        towerSell = GameObject.Find("TowerSell").GetComponent<AudioSource>();
        towerSellClip = towerSell.clip;
        
	}
	
	// Update is called once per frame
	void Update () {
        myColliders = null;//清空触发器列表
        #region//判断钱够不够的部分
        if (buildListIsActivated)//判断建筑列表是否激活
        {
            if (GameManager._gameCon.moneyManager >= 100)//实时更新，是否可以建造瓶子塔
            {
                bottleTowerIsActivated = true;
                GameObject temp;
                temp = GameObject.Find("Option_Bottle");
                if (temp != null)
                {
                    temp.transform.GetChild(0).gameObject.SetActive(true);
                    temp.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
            else
            {
                bottleTowerIsActivated = false;
                GameObject temp;
                temp = GameObject.Find("Option_Bottle");
                if (temp != null)
                {
                    temp.transform.GetChild(1).gameObject.SetActive(true);
                    temp.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            if (GameManager._gameCon.moneyManager >= 120)//实时更新，是否可以建造大便塔
            {
                shitTowerIsActivated = true;
                GameObject temp;
                temp = GameObject.Find("Option_Shit");
                if (temp != null)
                {
                    temp.transform.GetChild(0).gameObject.SetActive(true);
                    temp.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
            else
            {
                shitTowerIsActivated = false;
                GameObject temp;
                temp = GameObject.Find("Option_Shit");
                if (temp != null)
                {
                    temp.transform.GetChild(1).gameObject.SetActive(true);
                    temp.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        if (upgradeListIsActivated)
        {
            if (GameObject.Find("Upgrade").transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 1 && GameObject.Find("Upgrade").transform.parent.name == "BottleTower_Bottom")
            {
                if (GameManager._gameCon.moneyManager >= 180)
                {
                    upgradeTowerToLV2IsActivated = true;
                    GameObject temp;
                    temp = GameObject.Find("Upgrade");
                    if (temp != null)
                    {
                        temp.transform.GetChild(0).gameObject.SetActive(true);
                        temp.transform.GetChild(1).gameObject.SetActive(false);
                        temp.transform.GetChild(2).gameObject.SetActive(false);
                        temp.transform.GetChild(3).gameObject.SetActive(false);
                        temp.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
                else
                {
                    upgradeTowerToLV2IsActivated = false;
                    GameObject temp;
                    temp = GameObject.Find("Upgrade");
                    if (temp != null)
                    {
                        temp.transform.GetChild(1).gameObject.SetActive(true);
                        temp.transform.GetChild(0).gameObject.SetActive(false);
                        temp.transform.GetChild(2).gameObject.SetActive(false);
                        temp.transform.GetChild(3).gameObject.SetActive(false);
                        temp.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
            }
            if (GameObject.Find("Upgrade").transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 2 && GameObject.Find("Upgrade").transform.parent.name == "BottleTower_Bottom")
            {
                if (GameManager._gameCon.moneyManager >= 260)
                {
                    upgradeTowerToLV3IsActivated = true;
                    GameObject temp;
                    temp = GameObject.Find("Upgrade");
                    if (temp != null)
                    {
                        temp.transform.GetChild(0).gameObject.SetActive(false);
                        temp.transform.GetChild(1).gameObject.SetActive(false);
                        temp.transform.GetChild(2).gameObject.SetActive(true);
                        temp.transform.GetChild(3).gameObject.SetActive(false);
                        temp.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
                else
                {
                    upgradeTowerToLV3IsActivated = false;
                    GameObject temp;
                    temp = GameObject.Find("Upgrade");
                    if (temp != null)
                    {
                        temp.transform.GetChild(0).gameObject.SetActive(false);
                        temp.transform.GetChild(1).gameObject.SetActive(false);
                        temp.transform.GetChild(3).gameObject.SetActive(true);
                        temp.transform.GetChild(2).gameObject.SetActive(false);
                        temp.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
            }
            if (GameObject.Find("Upgrade").transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 3)
            {
                    GameObject temp;
                    temp = GameObject.Find("Upgrade");
                    if (temp != null)
                    {
                        temp.transform.GetChild(0).gameObject.SetActive(false);
                        temp.transform.GetChild(1).gameObject.SetActive(false);
                        temp.transform.GetChild(2).gameObject.SetActive(false);
                        temp.transform.GetChild(3).gameObject.SetActive(false);
                        temp.transform.GetChild(4).gameObject.SetActive(true);
                    }
            }
            if (GameObject.Find("Upgrade").transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 1 && GameObject.Find("Upgrade").transform.parent.name == "ShitTower_Bottom")
            {
                if (GameManager._gameCon.moneyManager >= 220)
                {
                    upgradeTowerToLV2IsActivated = true;
                    GameObject temp;
                    temp = GameObject.Find("Upgrade");
                    if (temp != null)
                    {
                        temp.transform.GetChild(0).gameObject.SetActive(true);
                        temp.transform.GetChild(1).gameObject.SetActive(false);
                        temp.transform.GetChild(2).gameObject.SetActive(false);
                        temp.transform.GetChild(3).gameObject.SetActive(false);
                        temp.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
                else
                {
                    upgradeTowerToLV2IsActivated = false;
                    GameObject temp;
                    temp = GameObject.Find("Upgrade");
                    if (temp != null)
                    {
                        temp.transform.GetChild(1).gameObject.SetActive(true);
                        temp.transform.GetChild(0).gameObject.SetActive(false);
                        temp.transform.GetChild(2).gameObject.SetActive(false);
                        temp.transform.GetChild(3).gameObject.SetActive(false);
                        temp.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
            }
            if (GameObject.Find("Upgrade").transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 2 && GameObject.Find("Upgrade").transform.parent.name == "ShitTower_Bottom")
            {
                if (GameManager._gameCon.moneyManager >= 320)
                {
                    upgradeTowerToLV3IsActivated = true;
                    GameObject temp;
                    temp = GameObject.Find("Upgrade");
                    if (temp != null)
                    {
                        temp.transform.GetChild(0).gameObject.SetActive(false);
                        temp.transform.GetChild(1).gameObject.SetActive(false);
                        temp.transform.GetChild(2).gameObject.SetActive(true);
                        temp.transform.GetChild(3).gameObject.SetActive(false);
                        temp.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
                else
                {
                    upgradeTowerToLV3IsActivated = false;
                    GameObject temp;
                    temp = GameObject.Find("Upgrade");
                    if (temp != null)
                    {
                        temp.transform.GetChild(0).gameObject.SetActive(false);
                        temp.transform.GetChild(1).gameObject.SetActive(false);
                        temp.transform.GetChild(3).gameObject.SetActive(true);
                        temp.transform.GetChild(2).gameObject.SetActive(false);
                        temp.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
            }
        }
        #endregion
        #region//判断能否建造
        if (Input.GetMouseButtonDown(0))//鼠标点击，获得触发器列表
        {
            buildPointCollider = null;
            mousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            myColliders = Physics2D.OverlapCircleAll(mousPosition, 0f);//获得点击位置的触发器列表
            foreach (Collider2D temp in myColliders)
            {
                if (temp.transform.tag == "Option" || temp.transform.tag == "Upgrade" || temp.transform.tag == "Sell")
                {
                    buildPointCollider = temp;
                    break;
                }
                if (temp.transform.tag == "Unbuild" || temp.transform.tag == "Bottom")
                {
                    buildPointCollider = temp;
                }
            }
            //foreach (Collider2D item in myColliders)
            //{
            //    print(item.name);
            //}
            if (buildPointCollider!=null)//判断列表是否为空
            {
                if (buildListIsActivated)//判断建造列表是否已激活
                {
                    if (buildPointCollider.tag == "Option" && buildPointCollider.name == "Option_Bottle")//判断触发器是否为Option触发器且为瓶子塔
                    {
                        if (bottleTowerIsActivated)//判断瓶子塔是否可以建造
                        {
                            towerBuild.PlayOneShot(towerBuildClip);
                            buildListIsActivated = false;
                            tempParent = null;
                            buildPointCollider.transform.parent.parent.GetChild(2).gameObject.SetActive(true);
                            //激活塔底座
                            buildPointCollider.transform.parent.parent.GetChild(2).GetChild(0).gameObject.SetActive(true);
                            buildPointCollider.transform.parent.parent.GetChild(2).GetChild(1).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.parent.GetChild(2).GetChild(2).gameObject.SetActive(false);
                            //激活LV1的塔
                            buildPointCollider.transform.parent.gameObject.SetActive(false);
                            //清空父物体，取消激活建造列表，建造塔LV1，扣钱
                        }
                        else
                        {
                            //播放不能建造的音频等
                        }
                    }
                    else if (buildPointCollider.tag == "Option" && buildPointCollider.name == "Option_Shit")//判断触发器是否为Option触发器且为大便塔
                    {
                        if (shitTowerIsActivated)//判断大便塔是否可以建造
                        {
                            towerBuild.PlayOneShot(towerBuildClip);
                            buildListIsActivated = false;
                            tempParent = null;
                            buildPointCollider.transform.parent.parent.GetChild(3).gameObject.SetActive(true);
                            //激活塔底座
                            buildPointCollider.transform.parent.parent.GetChild(3).GetChild(0).gameObject.SetActive(true);
                            buildPointCollider.transform.parent.parent.GetChild(3).GetChild(1).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.parent.GetChild(3).GetChild(2).gameObject.SetActive(false);
                            //激活LV1的塔
                            buildPointCollider.transform.parent.gameObject.SetActive(false);
                            //清空父物体，取消激活建造列表，建造塔LV1，扣钱
                        }
                        else
                        {
                            //播放不能建造的音频等
                        }
                    }
                    else
                    {
                        buildListIsActivated = false;
                        tempParent.transform.GetChild(0).gameObject.SetActive(true);
                        tempParent.transform.GetChild(1).gameObject.SetActive(false);
                        tempParent = null;
                        //清空父物体，取消激活建造列表，返回初始状态
                    }
                }
                else if(upgradeListIsActivated)//判断升级列表是否激活
                {
                    //print("建造");
                    if (buildPointCollider.tag == "Upgrade" && buildPointCollider.transform.parent.name == "BottleTower_Bottom")
                    {
                        if (upgradeTowerToLV2IsActivated)
                        {
                            towerUpgrade.PlayOneShot(towerUpgradeClip);
                            upgradeListIsActivated = false;
                            tempParent = null;
                            buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel = 2;
                            buildPointCollider.transform.parent.parent.GetChild(2).GetChild(0).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.parent.GetChild(2).GetChild(1).gameObject.SetActive(true);
                            buildPointCollider.transform.parent.parent.GetChild(2).GetChild(2).gameObject.SetActive(false);
                            //激活LV2的塔
                            buildPointCollider.transform.parent.GetChild(3).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.GetChild(4).gameObject.SetActive(false);
                            //隐藏升级列表
                        }
                        if (upgradeTowerToLV3IsActivated)
                        {
                            towerUpgrade.PlayOneShot(towerUpgradeClip);
                            upgradeListIsActivated = false;
                            tempParent = null;
                            buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel = 3;
                            buildPointCollider.transform.parent.parent.GetChild(2).GetChild(0).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.parent.GetChild(2).GetChild(1).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.parent.GetChild(2).GetChild(2).gameObject.SetActive(true);
                            //激活LV3的塔
                            buildPointCollider.transform.parent.GetChild(3).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.GetChild(4).gameObject.SetActive(false);
                            //隐藏升级列表
                        }
                        //print("升级完毕");
                    }
                    else if (buildPointCollider.tag == "Upgrade" && buildPointCollider.transform.parent.name == "ShitTower_Bottom")
                    {
                        if (upgradeTowerToLV2IsActivated)
                        {
                            towerUpgrade.PlayOneShot(towerUpgradeClip);
                            upgradeListIsActivated = false;
                            tempParent = null;
                            buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel = 2;
                            buildPointCollider.transform.parent.parent.GetChild(3).GetChild(0).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.parent.GetChild(3).GetChild(1).gameObject.SetActive(true);
                            buildPointCollider.transform.parent.parent.GetChild(3).GetChild(2).gameObject.SetActive(false);
                            //激活LV2的塔
                            buildPointCollider.transform.parent.GetChild(3).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.GetChild(4).gameObject.SetActive(false);
                            //隐藏升级列表
                        }
                        if (upgradeTowerToLV3IsActivated)
                        {
                            towerUpgrade.PlayOneShot(towerUpgradeClip);
                            upgradeListIsActivated = false;
                            tempParent = null;
                            buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel = 3;
                            buildPointCollider.transform.parent.parent.GetChild(3).GetChild(0).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.parent.GetChild(3).GetChild(1).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.parent.GetChild(3).GetChild(2).gameObject.SetActive(true);
                            //激活LV3的塔
                            buildPointCollider.transform.parent.GetChild(3).gameObject.SetActive(false);
                            buildPointCollider.transform.parent.GetChild(4).gameObject.SetActive(false);
                            //隐藏升级列表
                        }
                        //print("升级完毕");
                    }
                    else
                    {
                        towerSelectCancel.PlayOneShot(towerSelectCancelClip);
                        upgradeListIsActivated = false;
                        if (tempParent != null)
                        {
                            tempParent.transform.GetChild(2).GetChild(3).gameObject.SetActive(false);
                            tempParent.transform.GetChild(2).GetChild(4).gameObject.SetActive(false);
                            tempParent.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                            tempParent.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                            tempParent = null;
                        }
                        //取消升级列表
                    }
                    if (buildPointCollider.tag == "Sell" && buildPointCollider.transform.parent.name == "BottleTower_Bottom")
                    {
                        towerSell.PlayOneShot(towerSellClip);
                        upgradeListIsActivated = false;
                        tempParent = null;
                        if (buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 1)
                        {
                            Instantiate(BuildPointPrefab, buildPointCollider.transform.parent.parent.position, buildPointCollider.transform.parent.parent.rotation);
                            Destroy(buildPointCollider.transform.parent.parent.gameObject);
                            GameManager._gameCon.moneyManager += 80;
                            //隐藏塔
                        }
                        if (buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 2)
                        {
                            Instantiate(BuildPointPrefab, buildPointCollider.transform.parent.parent.position, buildPointCollider.transform.parent.parent.rotation);
                            Destroy(buildPointCollider.transform.parent.parent.gameObject);
                            GameManager._gameCon.moneyManager += 224;
                            //隐藏塔
                        }
                        if (buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 3)
                        {
                            Instantiate(BuildPointPrefab, buildPointCollider.transform.parent.parent.position, buildPointCollider.transform.parent.parent.rotation);
                            Destroy(buildPointCollider.transform.parent.parent.gameObject);
                            GameManager._gameCon.moneyManager += 432;
                            //隐藏塔
                        }
                    }
                    else if (buildPointCollider.tag == "Sell" && buildPointCollider.transform.parent.name == "ShitTower_Bottom")
                    {
                        towerSell.PlayOneShot(towerSellClip);
                        upgradeListIsActivated = false;
                        tempParent = null;
                        if (buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 1)
                        {
                            Instantiate(BuildPointPrefab, buildPointCollider.transform.parent.parent.position, buildPointCollider.transform.parent.parent.rotation);
                            Destroy(buildPointCollider.transform.parent.parent.gameObject);
                            GameManager._gameCon.moneyManager += 96;
                            //隐藏塔
                        }
                        if (buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 2)
                        {
                            Instantiate(BuildPointPrefab, buildPointCollider.transform.parent.parent.position, buildPointCollider.transform.parent.parent.rotation);
                            Destroy(buildPointCollider.transform.parent.parent.gameObject);
                            GameManager._gameCon.moneyManager += 272;
                            //隐藏塔
                        }
                        if (buildPointCollider.transform.parent.GetComponent<CurrentTowerLevel>().towerLevel == 3)
                        {
                            Instantiate(BuildPointPrefab, buildPointCollider.transform.parent.parent.position, buildPointCollider.transform.parent.parent.rotation);
                            Destroy(buildPointCollider.transform.parent.parent.gameObject);
                            GameManager._gameCon.moneyManager += 464;
                            //隐藏塔
                        }
                    }
                    else
                    {
                        towerSelectCancel.PlayOneShot(towerSelectCancelClip);
                        upgradeListIsActivated = false;
                        //print(tempParent.name);
                        if (tempParent != null)
                        {
                            tempParent.transform.GetChild(2).GetChild(3).gameObject.SetActive(false);
                            tempParent.transform.GetChild(2).GetChild(4).gameObject.SetActive(false);
                            tempParent.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                            tempParent.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                            tempParent = null;
                        }
                        //取消升级列表
                    }
                }
                else
                {
                    if (buildPointCollider.tag == "Unbuild")//判断触发器是否为Unbuild触发器
                    {
                        towerSelect.PlayOneShot(towerSelectClip);
                        buildListIsActivated = true;
                        tempParent = buildPointCollider.transform.parent.gameObject;
                        buildPointCollider.transform.parent.GetChild(1).gameObject.SetActive(true);
                        buildPointCollider.gameObject.SetActive(false);
                        //激活建造列表,记录父物体位置
                    }
                    if (buildPointCollider.tag == "Bottom")
                    {
                        towerSelect.PlayOneShot(towerSelectClip);
                        upgradeListIsActivated = true;
                        tempParent = buildPointCollider.transform.parent.gameObject;
                        buildPointCollider.transform.GetChild(3).gameObject.SetActive(true);
                        buildPointCollider.transform.GetChild(4).gameObject.SetActive(true);
                        //激活升级列表，记录父物体位置
                        if (buildPointCollider.GetComponent<CurrentTowerLevel>().towerLevel == 1)
                        {
                            buildPointCollider.transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
                            buildPointCollider.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                            buildPointCollider.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
                        }
                        if (buildPointCollider.GetComponent<CurrentTowerLevel>().towerLevel == 2)
                        {
                            buildPointCollider.transform.GetChild(4).GetChild(1).gameObject.SetActive(true);
                            buildPointCollider.transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
                            buildPointCollider.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
                        }
                        if (buildPointCollider.GetComponent<CurrentTowerLevel>().towerLevel == 3)
                        {
                            buildPointCollider.transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
                            buildPointCollider.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                            buildPointCollider.transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
                        }
                        //显示出售列表
                    }
                }
            }
            else
            {
                if (buildListIsActivated)
                {
                    towerSelectCancel.PlayOneShot(towerSelectCancelClip);
                    buildListIsActivated = false;
                    tempParent.transform.GetChild(0).gameObject.SetActive(true);
                    tempParent.transform.GetChild(1).gameObject.SetActive(false);
                    tempParent = null;
                    //取消建造列表，返回初始状态，清空父物体
                }
                if (upgradeListIsActivated)
                {
                    towerSelectCancel.PlayOneShot(towerSelectCancelClip);
                    upgradeListIsActivated = false;
                    tempParent.transform.GetChild(2).GetChild(3).gameObject.SetActive(false);
                    tempParent.transform.GetChild(2).GetChild(4).gameObject.SetActive(false);
                    tempParent.transform.GetChild(3).GetChild(3).gameObject.SetActive(false);
                    tempParent.transform.GetChild(3).GetChild(4).gameObject.SetActive(false);
                    tempParent = null;
                    //取消升级列表，返回初始状态，清空父物体
                }
            }
        }
        #endregion
    }
}
