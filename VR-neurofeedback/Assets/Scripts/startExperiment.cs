using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  
using System.IO;
using LSL;
using LSLOutputSpace;

public class startExperiment : MonoBehaviour
{
	public string sequenceFile = "Assets/Scripts/ME_run_1.txt";
	string[] sequence;
	int trials;
	// float t_task = 8f;
	// float t_fc = 2f;
	// float t_cue = 1.25f;
	// float t_fb = 5.75f;
	LSLOutput markerStream;


    // Start is called before the first frame update
    void Start()
    {	
		markerStream = GameObject.Find("LSLOutput").GetComponent<LSLOutput>();
		markerStream.createStreamOutlet();
			
		readSequence();
		displayTasks();		
    }

	
	// Reads the sequence from sequenceFile (e.g. ME_run_1.txt)
	void readSequence()
	{
		sequence = File.ReadAllLines(sequenceFile);  
        trials = sequence.Length;
	}
	
	void displayTasks()
	{
		foreach (string task in sequence)
		{
			// fixation-cross
			//print("fixation-cross");
			markerStream.pushSample("fixation-cross");
			//wait t_fc
			
			// cue
			// print(task);
			markerStream.pushSample(task);
			// // wait t_cue			
			// // receive fb stream
			// receiveFeedback();
		}
	}
	
	void receiveFeedback()
	{
		
	}
}
