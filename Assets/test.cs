using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    float currentTime;
    int count = 0;

	// Use this for initialization
	void Start () {
		currentTime= Time.time;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 offset = new Vector3(Time.deltaTime * 2, 0.0f, 0.0f);
        transform.position += offset;
        count++;
        if (count == 10)
        {
            Debug.Log(transform.position);
            Debug.Log(Time.time-currentTime);
        }
	}
}
