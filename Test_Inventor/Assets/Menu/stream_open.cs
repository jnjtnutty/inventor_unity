using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;



public class stream_open : MonoBehaviour {
	public static SerialPort stream = new SerialPort("COM4", 15200);
	// Use this for initialization
	void Start () {
		stream.Open ();
		//stream.ReadTimeout = 1;
		if (stream.IsOpen) {
			print ("yeah");
			readserial_menu ();
		}
	}


	
	// Update is called once per frame
	void Update () {


	}
	public void readserial_menu()
	{
		while (true) {
			string input = stream.ReadLine(); 
			if (input == "A") {
				print (input);
				stream.Write ("colors");
				SceneManager.LoadScene ("color");
				stream.Close ();
				break;
			} else if (input == "B") {
				print (input);
				stream.Write ("words");
				SceneManager.LoadScene ("word");
				stream.Close ();
				break;

			}
		}
	}
}
