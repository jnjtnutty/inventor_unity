using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class random_word : MonoBehaviour {

	// Use this for initialization
	public static TextAsset textfile;
	public static string[] dialogLines;
	private float time_game =120f;
	public static float round =20f;
	public static Text text1; 
	public static Text text2; 
	public static Text text3; 
	public static Text text4; 
	public Text time;
	public Text r;
	public static string dialog;

	// Update is called once per frame
	void Start(){
		

	}
	public static void random_word_func(){
		dialogLines = (textfile.text.Split('\n'));
		dialog = dialogLines [Random.Range (0,dialogLines.Length)];
		text1.text = dialog [0].ToString();
		text2.text = dialog [1].ToString();
		text3.text = dialog [2].ToString();
		text4.text = dialog [3].ToString();
		print (dialog);
	}
	public void Update () {
		time_game -= Time.deltaTime;
		if (time_game > 0) {
			time.text = "Time : " + (int  )time_game;
			round -= Time.deltaTime;
			r.text = "Round : " + (int)round;
			if (round < 0) {
				random_word_func ();
				round = 20f;
			}
		}
		else {
			time.text = "time up";

		}
	}
}
