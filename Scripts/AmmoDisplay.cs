using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {
    public int weaponAIM;
    public int leftAmmo;
    public Text ammo;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Ammo();
	}

    void Ammo()
    {
        ammo.text = weaponAIM + "/" + leftAmmo;
    }
}
