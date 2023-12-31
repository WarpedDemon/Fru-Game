﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitEmitter : MonoBehaviour
{
    //aka upgraded call using unity cos sence
    [SerializeField]
    ObjectManager manager;

    public GameObject Bullet_Emitter;
    public GameObject Bullet;

    // Use this for initialization
    void Start()
    {
       // manager = GetComponent<ObjectManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (manager.EmitterOn == true && manager.fruCount < manager.maxUnits && manager.deleteObj != true)
        {
                manager.fruCount += 1;
                //The Bullet instantiation happens here.
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                Temporary_Bullet_Handler.transform.Rotate(Vector3.up * 90);

                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce(transform.forward * manager.Bullet_Forward_Force);

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            
                //Destroy(Temporary_Bullet_Handler, 1.0f);
                //numberObj.text = units.ToString();
        }

        if (manager.deleteObj == true && manager.fruCount > 0)
        {
            manager.fruCount -= 1;
            manager.updateUi();
        }
    }
}
