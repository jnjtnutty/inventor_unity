using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class time_random_color : MonoBehaviour {

	// Use this for initialization

	public Text time;
	public static Text r;
	public static Text g;
	public static Text p;
	public static Text b;
	public static float time_game = 120f;
	public static float round;
	public static int[] values;

	void Start () {
		round = 20f;
	}

	public static void  random_num_func()
	{
		values = new int[4];
		while (values [0] + values [1] + values [2] + values [3] != 8) {
			for (int i = 0; i <= 3; i++) {
				values [i] = Random.Range (0, 6);
			}
		}
		r.text = values [0].ToString();
		g.text = values [1].ToString();
		p.text = values [2].ToString();
		b.text = values[3].ToString();
	}

	// Update is called once per frame
	void Update () {
		time_game -= Time.deltaTime;
		if (time_game > 0) {
			time.text = "Time : " + (int  )time_game;
			round -= Time.deltaTime;
			r.text = "Round : " + (int)round;
			if (round < 0) {
				random_num_func();
				round = 20f;
				for (int i = 0; i <= 3; i++) {
					values [i] = 0;
				}
			} 
		}
		else {
			time.text = "time up";
			SceneManager.LoadScene("score_color");
		}
			

	}
}