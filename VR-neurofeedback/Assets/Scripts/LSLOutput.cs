using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;
using System;

namespace LSLOutputSpace
{
public class LSLOutput: MonoBehaviour
{
    liblsl.StreamOutlet outlet;

    string StreamName = "Marker";
    string StreamType = "Markers";
    string StreamId = "sequenceID0000";

    // Start is called before the first frame update
    public void createStreamOutlet()
    {
        liblsl.StreamInfo streamInfo = new liblsl.StreamInfo(StreamName, StreamType, 1, 0, liblsl.channel_format_t.cf_string, StreamId);
        outlet = new liblsl.StreamOutlet(streamInfo);
    }
	
	public void pushSample(string currentSample)
	{
		string[] sample = new string[1];
		sample[0] = currentSample;
		print("push sample: " + sample[0]);
		outlet.push_sample(sample);
		//System.Threading.Thread.Sleep(rnd.Next(1000));
	}

}
}
