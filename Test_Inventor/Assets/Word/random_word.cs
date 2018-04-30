using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using System;

public class random_word : MonoBehaviour {

	// Use this for initialization
	public  TextAsset textfile;
	public  string[] dialogLines;
	private float time_game =120f;
	public  float round =20f;
	public Text text1; 
	public Text text2; 
	public Text text3; 
	public Text text4; 
	public Text time;
	public Text r;
	public string dialog;
	public int score_w = 0;
	int q1,q2,q3,q4 =0; 

	// Update is called once per frame
	void Start(){
		

	}
	public void random_word_func(){
		dialogLines = (textfile.text.Split('\n'));
		dialog = dialogLines [UnityEngine.Random.Range (0,dialogLines.Length)];
		text1.text = dialog [0].ToString();
		text2.text = dialog [1].ToString();
		text3.text = dialog [2].ToString();
		text4.text = dialog [3].ToString();
		print (dialog);
	}
	public void Update () {
		time_game -= Time.deltaTime;
		if (time_game > 0) {
			time.text = "Time : " + (int)time_game;
			round -= Time.deltaTime;
			r.text = "Round : " + (int)round;
			if (round < 0) {
				random_word_func ();
				round = 20f;
			} else {
				while (q1 == 0 || q2 == 0 || q3 == 0 || q4 == 0) {
					StartCoroutine (AsyncReadFromArduino ((string s) => Debug.Log (s), () => Debug.LogError ("Error"), 10000f));
					if (q1 == 1 && q2 == 1 && q3 == 1 && q4 == 1) {
						break;
					}
				}
				if (q1 == 1 && q2 == 1 && q3 == 1 && q4 == 1) {
					score_w += 1;
					random_word_func ();
					round = 20;
					q1 = 0;
					q2 = 0;
					q3 = 0;
					q4 = 0;
				}
			}
		} else {
			time.text = "time up";
		}
	}

	public IEnumerator AsyncReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity){
		DateTime initialTime = DateTime.Now;
		DateTime nowTime;
		TimeSpan diff = default(TimeSpan);
		string dataString = null;

		do {
			try {
				string tx1 = text1.ToString ();
				string tx2 = text2.ToString ();
				string tx3 = text3.ToString ();
				string tx4 = text4.ToString ();
				dataString = stream_open.stream.ReadLine ();
				if (dataString == tx1) {
					q1 += 1;
				} else if (dataString == tx1.ToLower ()) {
					q1 -= 1;
				}
				if (dataString == tx2) {
					q2 += 1;
				} else if (dataString == tx2.ToLower ()) {
					q2 -= 1;
				}
				if (dataString == tx3) {
					q3 += 1;
				} else if (dataString == tx3.ToLower ()) {
					q3 -= 1;
				}
				if (dataString == tx4) {
					q4 += 1;
				} else if (dataString == tx4.ToLower ()) {
					q4 -= 1;
				}


			} catch (TimeoutException) {
				dataString = null;
			}

			if (dataString != null) {
				callback (dataString);
				yield return null;
			} else {
				yield return new WaitForSeconds (0.05F);
				nowTime = DateTime.Now;
				diff = nowTime - initialTime;
			}
		} while (diff.Milliseconds < timeout);

		if (fail != null) {
			fail ();
			yield return null;
		}
	}
}
