using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcollision : MonoBehaviour {

    public float minD = 1.0f;
    public float maxD = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollydir;
    public Vector3 diradjusted;
    public float distance;

	// Use this for initialization
	void Awake () {
        dollydir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 desiredcampos = transform.parent.TransformPoint(dollydir * maxD);
        RaycastHit hit;

        if(Physics.Linecast (transform.parent.position, desiredcampos, out hit))
        {
            distance = Mathf.Clamp((hit.distance * 0.9f), minD, maxD);

        }
        else
        {
            distance = maxD;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollydir * distance, Time.deltaTime * smooth);
	}
}
