using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class serial_test : MonoBehaviour {

	SerialPort stream = new SerialPort("COM3", 15200);
	// Use this for initialization
	void Start () {
		stream.Open();


	}
	// Update is called once per frame
	void Update () {
		
	}
	public void TaskOnClick(){
		stream.Write("Nutty");
		string value = stream.ReadLine ();
		Debug.Log (value);
	}




}
