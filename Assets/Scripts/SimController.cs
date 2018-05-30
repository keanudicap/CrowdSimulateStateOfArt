using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MengeCS;
using System;
using System.IO;


public class SimController : MonoBehaviour {
	
	public GameObject PedestrianModel;

	private MengeCS.Simulator _sim;
	private List<GameObject> _objects = new List<GameObject>();
    private bool _sim_is_valid = false;
    private bool createOnlyOnce = false;
    private List<Color> colors = new List<Color>();

	private List<Color> classColors = new List<Color> () {
		Color.red,
		Color.blue,
		Color.green,
		Color.gray,
		Color.magenta
	};

	// Use this for initialization
	void Start () {
		Debug.Log ("Starting simulation...");

		string demo = "hallway";        
		//string mengeRoot = @"F:\KTH\Menge\Menge-master\";
        string path = Application.dataPath;
        //string behavior = Path.Combine(path, @"examples\4square\4squareB.xml");
        //string scene = Path.Combine(path, @"examples\4square\4squareS.xml");
        string behavior = Path.Combine(path, String.Format(@"examples\{0}\{0}B.xml", demo));
        string scene = Path.Combine(path, String.Format(@"examples\{0}\{0}S.xml", demo));
        string pluginsPath = Path.Combine(path, @"Plugins\x86_64");
        //string pluginsPath = @"F:\KTH\Menge\MengeUnity-master\Assets\Plugins\x86\plugins\";
        //string pluginsPath = @"F:\KTH\Menge\Menge-master\projects\VS2015\Plugins\build\lib\x64\";        
        //string pluginsPath = @"F:\KTH\Menge\Menge-master\projects\VS2015\Plugins\build\x64\Release\AgtHelbing";
        Debug.Log ("\tInitialzing sim");
		Debug.Log ("\t\tBehavior: " + behavior);
		Debug.Log ("\t\tScene: " + scene);

		_sim = new MengeCS.Simulator ();
        _sim_is_valid = _sim.Initialize (behavior, scene, "orca", pluginsPath);

        if (_sim_is_valid)
        {
            int COUNT = _sim.AgentCount;
            Debug.Log(string.Format("Simulator initialized with {0} agents", COUNT));
            TimerManager timeManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
            if (timeManager == null)
            {
                Debug.Log("Add time manager");
            }else
            {
                timeManager.SetAgentCount(COUNT);
            }
            for (int i = 0; i < COUNT; ++i)
            {
                MengeCS.Agent a = _sim.GetAgent(i);
                UnityEngine.Vector3 pos = new UnityEngine.Vector3(a.Position.X, a.Position.Y, a.Position.Z);
                GameObject o = Instantiate(PedestrianModel, pos, Quaternion.identity) as GameObject;
                if (o != null)
                {
                    o.transform.GetComponentInChildren<Renderer>().material.color = classColors[a.Class % classColors.Count];
                    o.transform.GetChild(0).gameObject.transform.localScale = new UnityEngine.Vector3(a.Radius * 2, 0.85f, a.Radius * 2);
                    _objects.Add(o);
                    o.name = i.ToString();
                    Timer timer = o.GetComponentInChildren<Timer>();
                    //Debug.Log(a.Class);
                    if (a.Class == 0)
                    {
                        if (demo == "crossing")
                        {
                            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            timer.setGoal(goal);
                            goal.name = "goal" + i.ToString();
                            goal.transform.position = new UnityEngine.Vector3(-pos.x, pos.y+0.5f, pos.z);
                            goal.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                        }
                        else if (demo == "intersection")
                        {
                            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            timer.setGoal(goal);
                            goal.name = "goal" + i.ToString();
                            goal.transform.position = new UnityEngine.Vector3(-pos.x, pos.y + 0.5f, pos.z);
                            goal.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                        }
                        else if (demo == "bottleneck")
                        {
                            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            timer.setGoal(goal);
                            goal.name = "goal" + i.ToString();
                            goal.transform.position = new UnityEngine.Vector3(-pos.x, pos.y + 0.5f, pos.z);
                            goal.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                            //createOnlyOnce = true;
                        }
                        else if (demo == "circle" || demo == "circlemore")
                        {
                            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            timer.setGoal(goal);
                            goal.name = "goal" + i.ToString();
                            goal.transform.position = new UnityEngine.Vector3(-pos.x, pos.y + 0.5f, -pos.z);
                            goal.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                        }
                        else if (demo == "hallway")
                        {
                            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            timer.setGoal(goal);
                            goal.name = "goal" + i.ToString();
                            goal.transform.position = new UnityEngine.Vector3(pos.x, pos.y + 0.5f, -pos.z);
                            goal.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                        }
                        else if (demo == "testthree")
                        {
                            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            timer.setGoal(goal);
                            goal.name = "goal" + i.ToString();
                            goal.transform.position = new UnityEngine.Vector3(-pos.x, pos.y + 0.5f, -pos.z);
                            goal.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                        }

                    }
                    else
                    {
                        if (demo == "crossing")
                        {
                            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            timer.setGoal(goal);
                            goal.name = "goal" + i.ToString();
                            goal.transform.position = new UnityEngine.Vector3(pos.x, pos.y+0.5f, -pos.z);
                            goal.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                        }
                        else if (demo == "intersection")
                        {
                            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            timer.setGoal(goal);
                            goal.name = "goal" + i.ToString();
                            goal.transform.position = new UnityEngine.Vector3(-pos.x, pos.y + 0.5f, pos.z);
                            goal.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                        }
                        else if (demo == "hallway")
                        {
                            GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            timer.setGoal(goal);
                            goal.name = "goal" + i.ToString();
                            goal.transform.position = new UnityEngine.Vector3(pos.x, pos.y + 0.5f, -pos.z);
                            goal.transform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                        }
                    }
                }
            }
        } else
        {
            Debug.Log("Failed to initialize the simulator...");
        }
        for (int i = 0; i < _sim.AgentCount; ++i)
        {
            float ratio = ((float)i / (float)_sim.AgentCount);
            float randomNum = UnityEngine.Random.Range(0.0f, 1.0f);
            Color newColor;
            if (randomNum < 0.3f)
            {
                 newColor = new Color(randomNum, (1.0f - ratio), (1.0f + ratio) / 2.0f, 1.0f);
            }
            else if (randomNum >= 0.3f && randomNum < 0.6f)
            {
                 newColor = new Color((1.0f - ratio), (1.0f + ratio) / 2.0f, randomNum);
            }
            else
            {
                 newColor = new Color(10f, (1.0f - ratio), (1.0f + ratio) / 2.0f, randomNum);
            }
            colors.Add(newColor);
        }

    }


    void DrawLine(UnityEngine.Vector3 start, UnityEngine.Vector3 end, Color color, float duration = 10f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.025f, 0.025f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (_sim_is_valid)
        {
            _sim.DoStep();

            UnityEngine.Vector3 newPos = new UnityEngine.Vector3();
            for (int i = 0; i < _sim.AgentCount; ++i)
            {
                MengeCS.Vector3 pos3d = _sim.GetAgent(i).Position;
               // var orient = new UnityEngine.Vector2(_sim.GetAgent(i).Orientation.X, _sim.GetAgent(i).Orientation.Y);
                //Debug.Log(orient);                
                newPos.Set(pos3d.X, pos3d.Y, pos3d.Z);
                DrawLine(_objects[i].transform.position, newPos, colors[i], 200);
                _objects[i].transform.position = newPos;
                
            }
        }
	}
}
