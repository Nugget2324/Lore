using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character1 : MonoBehaviour {

    Rigidbody rigid;
    Animator anim;


	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        movement(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), Input.GetAxis("Jump"));
	}

    void movement(float vert, float horiz, float jump)
    {
        rigid.velocity = (transform.forward * vert * 10);
    }
}
