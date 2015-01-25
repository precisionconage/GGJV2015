﻿using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour {
    
    public GameObject carrot;
    public GameObject world;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject c = (GameObject)Instantiate(carrot, this.transform.position, this.transform.rotation);
            c.transform.parent = world.transform;
        }
	}
}