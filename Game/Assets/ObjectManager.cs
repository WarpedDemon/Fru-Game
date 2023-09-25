using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour {
    //aka upgraded call using unity cos sence
    [SerializeField]
    public Canvas canvas;
    public Text numberObj;
    public int maxUnits = 1;
    public float Bullet_Forward_Force;
    public bool EmitterOn = false;
    public int fruCount;
    public bool deleteObj;
    // Use this for initialization
    void Start () {
        fruCount = Convert.ToInt32(numberObj.text);
        numberObj.text = ""+fruCount.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        //numberObj.text = units.ToString();
        numberObj.text = "" + fruCount.ToString();
        Debug.Log("Fruit on screen: " + numberObj.text);

    }
    public void updateUi()
    {
        numberObj.text = "" + fruCount.ToString();
        Debug.Log("Fruit on screen: " + numberObj.text);
    }
}
