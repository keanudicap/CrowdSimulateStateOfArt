using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    GameObject goalObject;
    float ellapsedTime;
    float currentTime;
    TimerManager timerManager;
	// Use this for initialization
	void Start () {
        ellapsedTime = 0;
        currentTime = Time.time;
        timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setGoal(GameObject goal)
    {
        goalObject = goal;
    }

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject)
        {
            return;
        }

        if (col.gameObject == goalObject && gameObject.transform.parent.name == goalObject.name.Substring(goalObject.name.LastIndexOf('l') + 1))
        {
            ellapsedTime = Time.time - currentTime;
            timerManager.AddTime(ellapsedTime);
        }

        if (col.gameObject.tag == "pedestrian" || col.gameObject.tag == "wall")
        {
            timerManager.AddCollision();
        }
    }
}
