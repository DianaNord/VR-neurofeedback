using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{
	internal List<string> blockSequence;       // sequence of conditions
	private string condition;                  // right hand or left hand
	internal LSLMarkerStream markerStream;     // LSL marker stream
	int round = -1;                            // number of the trial
	
	public int n_block = 1;                    // number of sequence
    string path = "Assets/Resources/ME_run_";  // path to the sequences
	
	public GameObject fixationCross;
	public GameObject arrowLeft;
	public GameObject arrowRight;
	public GameObject endText;
	public GameObject brain;
	
	
    void Start()
    {
		blockSequence = new List<String>(File.ReadAllLines(path+n_block+".txt"));
		markerStream = gameObject.GetComponent<LSLMarkerStream>();
		StartBlock();        
    }
	
	void StartBlock()
    {
        markerStream.Write("Experiment_Start");
        round = 0;
        condition = blockSequence[round];
        StartTrial(condition);
    }
	
	void StartTrial(string condition)
    {
		markerStream.Write("Start_Trial_" + condition);
		fixationCross.SetActive(true);
		StartCoroutine(DisplayTask(condition));        
    }
	
	public void EndTrial()
    {
		brain.SetActive(false);
		
        markerStream.Write("End_of_Trial");
		
        round = round + 1;
        if (round >= blockSequence.Count)
        {
            BlockFinished();
        }
        else
        {
            condition = blockSequence[round];
            StartCoroutine(NextTrial(condition));
        }        
    }
	
	void BlockFinished() 
    {
        markerStream.Write("End_of_Experiment");
        endText.SetActive(true);
    }
	
	
	IEnumerator NextTrial(string condition)
    {
        yield return new WaitForSeconds(3);
        StartTrial(condition);
    }
	

	IEnumerator DisplayTask(string condition)
    {
		yield return new WaitForSeconds(2);
		switch (condition)
        {
            case "ME_r":
				arrowRight.SetActive(true);
                break;                
            case "ME_l":
				arrowLeft.SetActive(true);
                break;
        }
		yield return new WaitForSeconds(2);
		arrowLeft.SetActive(false);
		arrowRight.SetActive(false);
		fixationCross.SetActive(false);

		// display feedback
		brain.SetActive(true);
		yield return new WaitForSeconds(6);
		EndTrial();		
    }

    void Update()
    {
        
    }
}
