using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour {

    List<float> timeList = new List<float>();
    int numberOfCollision;
    int numberOfAgent;
    float averageCollision;
    bool done;
	// Use this for initialization
	void Start () {
        numberOfCollision = 0;
        done = false;
	}

    private void Update()
    {
        if(timeList.Count==numberOfAgent&&numberOfAgent!=0&&!done)
        {
            done = true;
            float averageTime = 0;
            foreach (var time in timeList)
            {
                averageTime += time;
            }
            averageTime /= numberOfAgent;
            averageCollision = numberOfCollision / numberOfAgent;
            float standardDeviation = StandardDeviation(timeList, averageTime);
            Debug.Log(averageTime);
            Debug.Log(averageCollision);
            Debug.Log("numer of agents = " + numberOfAgent.ToString());
            Debug.Log("standard deviation = " + standardDeviation.ToString());
        }

        if (timeList.Count > numberOfAgent)
        {
            bool comehere = true;
        }
    }

    public float StandardDeviation(List<float> timeList, float mean)
    {
        float SD = 0.0f;
        foreach (var time in timeList)
        {
            SD += (time-mean)* (time - mean);
        }
        SD /= (timeList.Count - 1);
        return Mathf.Sqrt(SD);
    }

    public void SetAgentCount(int num)
    {
        numberOfAgent = num;
    }

    public void AddTime(float time)
    {
        if (timeList.Count < numberOfAgent)
        {
            timeList.Add(time);
        }
                
    }

    public void AddCollision()
    {
        if(timeList.Count<numberOfAgent)
        {
            numberOfCollision += 1;
        }        
    }

}
