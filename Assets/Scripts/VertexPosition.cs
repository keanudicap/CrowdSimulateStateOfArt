using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexPosition : MonoBehaviour {
    MeshFilter mf;

    // Use this for initialization
    void Start () {
        mf = this.gameObject.GetComponent<MeshFilter>();
        for (int i = 0; i < mf.mesh.vertices.Length; ++i)
        {
            Vector3 world_v = transform.localToWorldMatrix.MultiplyPoint3x4(mf.mesh.vertices[i]);
            Debug.Log(world_v);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
