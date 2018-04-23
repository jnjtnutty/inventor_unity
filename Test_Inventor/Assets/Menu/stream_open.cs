using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class stream_open : MonoBehaviour {
	public static SerialPort stream = new SerialPort("COM4", 15200);
	// Use this for initialization
	void Start () {
		stream.Open();

	}
	
	// Update is called once per frame
	void Update () {
		if (color_select.count >= 7) {
			stream.Write("colors");
			string value = stream.ReadLine ();
			Debug.Log (value);
		}
		if (word_select.count >= 7) {
			stream.Write("words");
			string value = stream.ReadLine ();
			Debug.Log (value);
		}
	}
}
