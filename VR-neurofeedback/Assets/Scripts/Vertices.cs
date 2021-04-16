using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = System.Random;

public class Vertices : MonoBehaviour
{
	public Gradient gradient;
    // Start is called before the first frame update
    void Start()
    {
		var uv_file = File.CreateText("UV_map.txt");
		
		
		GameObject brain = GameObject.Find("brain/Brain_Part_06/Brain_Part_06_Colour_Brain_Texture_0");
		GameObject brain2 = GameObject.Find("Brain/Brain_Part_06 (right hem.)");
		//print(brain.transform.position);
		Vector3[] objectVerts = brain2.GetComponent<MeshFilter>().mesh.vertices;
		Vector2[] objectUV = brain2.GetComponent<MeshFilter>().mesh.uv;
		Color[] colors;
		colors = new Color[objectVerts.Length];
		Random rand = new Random();
		print("Vertex length: " + objectVerts.Length);
		print("UV length: " + objectUV.Length);
		int i=0;
        foreach (Vector3 vert in objectVerts)
		{
			print("Vertice: " + vert);
			print("UV     : " + objectUV[i].x + " " + objectUV[i].y);
			// colors[i] = gradient.Evaluate((float) rand.NextDouble());
			colors[i] = gradient.Evaluate(0.0f);

			uv_file.WriteLine ("{0};{1}", objectUV[i].x, objectUV[i].y);			
			i++;
		}
		brain2.GetComponent<MeshFilter>().mesh.colors = colors;
		print("Finished");
		
		
        
        uv_file.Close();
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
