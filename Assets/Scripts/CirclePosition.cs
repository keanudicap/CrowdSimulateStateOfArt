using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CirclePosition : MonoBehaviour {
    public int numberOfAgent;
    List<Vector2> positions = new List<Vector2>();
    public float radius;
    public GameObject prefab;
    float angle;
	// Use this for initialization
	void Start () {
        float offset = 2*Mathf.PI / numberOfAgent;
        angle = 0.0f;
        string path = "Assets/Resources/circlePositions.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        for (int i = 0; i < numberOfAgent; i++)
        {
            var pos = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
            positions.Add(pos);
            GameObject agent = Instantiate(prefab, new Vector3(pos.x, 0.0f, pos.y), Quaternion.identity);
           // Debug.Log(pos);
            angle += offset;
            writer.WriteLine("<Agent p_x=\"" + pos.x.ToString() +"\" p_y=\""+ pos.y.ToString()+"\" />");
        }
        
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = Resources.Load("test") as TextAsset;

        //Print the text from the file
        Debug.Log(asset.text);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
