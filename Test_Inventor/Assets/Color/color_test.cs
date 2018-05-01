using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using UnityEngine.SceneManagement;
using System;


public class color_test : MonoBehaviour {

	// Use this for initialization
	public static SerialPort stream = new SerialPort("COM3", 9600);

	public Text time;
	public Text round;
	public Text r;
	public Text g;
	public Text p;
	public Text b;
	public int[] values;
	public float time_game = 120f;
	public float round_game = 20f;
	public int score_c = 0;
	int red,green,pink,blue;


	void Start () {
		stream.Open ();
		random_num_func ();
		red = values [0];
		green = values [1];
		pink = values [2];
		blue = values [3];
		print ("0:" + values [0] + " 1:" + values [1] + " 2:" + values [2] + " 3:" + values [3]);
	}
	
	// Update is called once per frame
	void Update () {
		time_game -= Time.deltaTime;
		if (time_game > 0) {
			time.text = "Time : " + (int)time_game;
			round_game -= Time.deltaTime;
			round.text = "Round : " + (int)round_game;
			if (round_game < 0) {
				random_num_func ();
				for (int i = 0; i <= 3; i++) {
					values [i] = 0;
				}
				red = values [0];
				green = values [1];
				pink = values [2];
				blue = values [3];
				print (values [0] + " " + values [1] + " " + values [2] + " " + values [3]);
			} 
			else {
				
				StartCoroutine(AsyncReadFromArduino((string s) => Debug.Log(s), () => Debug.LogError("Error"), 10000f));
			/*	int red = values [0];
				int green = values [1];
				int pink = values [2];
				int blue = values [3];
				print ("0:" + values [0] + " 1:" + values [1] + " 2:" + values [2] + " 3:" + values [3]);
				while (values [0] != 0 && values [1] != 0 && values [2] != 0 && values [3] != 0) {
					string input = stream_open.stream.ReadLine ();
					print (input);
					switch (input) {
					case("R"):
						red -= 1;
						break;
					case("r"):
						red += 1;
						break;
					case("G"):
						green -= 1;
						break;
					case("g"):
						green += 1;
						break;
					case("P"):
						pink -= 1;
						break;
					case("p"):
						pink += 1;
						break;
					case("B"):
						blue -= 1;
						break;
					case("b"):
						blue += 1;
						break;
					}
					print ("red: " + red + " green: " + green + " blue: " + blue + " pink: " + pink);
					if (red == 0 && green == 0 && blue == 0 && pink == 0) {
						break;
					}
				}
				if (red == 0 && green == 0 && blue == 0 && pink == 0) {
					score_c += 1;
					random_num_func ();
					round_game = 20;
				}*/
			}
		}
		else {
			time.text = "time up";
			stream.Write ("exit");
			SceneManager.LoadScene("score_color");
		}
	}

	public IEnumerator AsyncReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity){
		DateTime initialTime = DateTime.Now;
		DateTime nowTime;
		TimeSpan diff = default(TimeSpan);
		//int count_a;
		//int count_b;

		string dataString = null;

		do{
			try{
				dataString = stream.ReadLine();
				Debug.Log(dataString);
				while (values [0] != 0 && values [1] != 0 && values [2] != 0 && values [3] != 0) {
					switch (dataString) {
					case("R"):
						red -= 1;
						break;
					case("r"):
						red += 1;
						break;
					case("G"):
						green -= 1;
						break;
					case("g"):
						green += 1;
						break;
					case("P"):
						pink -= 1;
						break;
					case("p"):
						pink += 1;
						break;
					case("B"):
						blue -= 1;
						break;
					case("b"):
						blue += 1;
						break;
					}
					print ("red: " + red + " green: " + green + " blue: " + blue + " pink: " + pink);
					if (red == 0 && green == 0 && blue == 0 && pink == 0) {
						break;
					}
				}
				if (red == 0 && green == 0 && blue == 0 && pink == 0) {
					score_c += 1;
					random_num_func ();
					round_game = 20;
				}
			}
			catch(TimeoutException){
				dataString = null;
			}

			if(dataString != null){
				callback(dataString);
				yield return null;
			}else
			{
				yield return new WaitForSeconds(0.05F);
				nowTime = DateTime.Now;
				diff = nowTime - initialTime;
			}
		}while (diff.Milliseconds < timeout);

		if(fail != null){
			fail();
			yield return null;
		}
	}


	public void  random_num_func()
	{
		values = new int[4];
		while (values [0] + values [1] + values [2] + values [3] != 8) {
			for (int i = 0; i <= 3; i++) {
				values [i] = UnityEngine.Random.Range (1, 5);
			}
		}
		r.text = values [0].ToString();
		g.text = values [1].ToString();
		p.text = values [2].ToString();
		b.text = values [3].ToString();
		stream.Write ("next");
		round_game = 20f;
		print ("random");
	}
}
