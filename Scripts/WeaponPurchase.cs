using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPurchase : MonoBehaviour {
    public GameObject weaponList;
    public GameObject playerWeapon;
    public Text moneySum;
    public GameObject[] weapons;
    public bool inPurchase;
    public float currentMoney;
    KeyCode currentKey;

    void Awake()
    {
        currentMoney = 0f;
    }
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        MoneyUpdate();
	}

    void Purchase()
    {
        if (Input.GetKey(KeyCode.B))
        {
            weaponList.SetActive(true);
            inPurchase = true;
        }
        if (Input.anyKeyDown && inPurchase)
        {
            KeyCode key = Event.current.keyCode;
            switch(key)
            {
                case KeyCode.Alpha0:
                    WeaponChange(weapons[0]);
                    break;
                case KeyCode.Alpha1:
                    WeaponChange(weapons[1]);
                    break;
                case KeyCode.Alpha2:
                    WeaponChange(weapons[2]);
                    break;
                case KeyCode.Alpha3:
                    WeaponChange(weapons[3]);
                    break;
                case KeyCode.Alpha4:
                    WeaponChange(weapons[4]);
                    break;
                case KeyCode.Alpha5:
                    WeaponChange(weapons[5]);
                    break;
                case KeyCode.Alpha6:
                    WeaponChange(weapons[6]);
                    break;
                case KeyCode.Alpha7:
                    WeaponChange(weapons[7]);
                    break;
                case KeyCode.Alpha8:
                    WeaponChange(weapons[8]);
                    break;
                case KeyCode.Alpha9:
                    WeaponChange(weapons[9]);
                    break;
                case KeyCode.Escape:
                    weaponList.SetActive(false);
                    inPurchase = false;
                    break;
                default:
                    break;
            }
        }
    }

    void OnGUI()
    {
        Purchase();
        /*if (Input.anyKeyDown &&inPurchase)
        {
            KeyCode key= Event.current.keyCode;
            Debug.Log(key);
        }*/
    }

    void WeaponChange(GameObject weapon)
    {
        if (currentMoney > weapon.GetComponent<WeaponData>().weaponPrice)
        {
            Destroy(playerWeapon.transform.GetChild(0).gameObject);
            //Debug.Log(playerWeapon.transform.childCount);
            if (playerWeapon.transform.childCount <= 1)
            {
                GameObject currentWeapon = Instantiate(weapon);
                currentWeapon.transform.parent = playerWeapon.transform;
                currentWeapon.transform.position = playerWeapon.transform.position;
                currentWeapon.transform.rotation = playerWeapon.transform.rotation;
            }
        }
    }

    void MoneyUpdate()
    {
        moneySum.text = "$:" + currentMoney;
    }
}
