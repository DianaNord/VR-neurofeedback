﻿using UnityEngine;
using System.Collections;
using LSL;

public class LSLMarkerStream : MonoBehaviour
{
	private const string unique_source_id = "VR7373NF";

	public string lslStreamName = "Unity_Scenario_Stream";
	public string lslStreamType = "LSL_Marker_Strings";

	private liblsl.StreamInfo lslStreamInfo;
	private liblsl.StreamOutlet lslOutlet;
	private int lslChannelCount = 1;

	private double nominal_srate = liblsl.IRREGULAR_RATE;
	private const liblsl.channel_format_t lslChannelFormat = liblsl.channel_format_t.cf_string;

	private string[] sample;

	void Awake()
	{
		sample = new string[lslChannelCount];

		lslStreamInfo = new liblsl.StreamInfo(
									lslStreamName,
									lslStreamType,
									lslChannelCount,
									nominal_srate,
									lslChannelFormat,
									unique_source_id);
		
		lslOutlet = new liblsl.StreamOutlet(lslStreamInfo);
	}

	public void Write(string marker)
	{
		sample[0] = marker;
		lslOutlet.push_sample(sample);
		print(marker);
	}

	// public void Write(string marker, double customTimeStamp)
	// {
		// sample[0] = marker;
		// lslOutlet.push_sample(sample, customTimeStamp);
	// }

	// public void Write(string marker, float customTimeStamp)
	// {
		// sample[0] = marker;
		// lslOutlet.push_sample(sample, customTimeStamp);
	// }

	// public void WriteBeforeFrameIsDisplayed(string marker)
	// {
		// StartCoroutine(WriteMarkerAfterImageIsRendered(marker));
	// }

	// IEnumerator WriteMarkerAfterImageIsRendered(string pendingMarker)
	// {
		// yield return new WaitForEndOfFrame();

		// Write(pendingMarker);

		// yield return null;
	// }
}