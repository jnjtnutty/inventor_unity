using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class random_color : MonoBehaviour {


	public GameObject[] pic; 
	public Text time;
//	private float time_game;
//	private float round;
	private int[] values;

	void Start () {
		//time_game = 120f;
		//round = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		
		random_color_func();
	}
	public void random_color_func()
	{
		values = new int[4];
		for (int i = 0; i <= 3; i++) {
			values [i] = Random.Range (0,5);
			switch (values [i]) {
			case 0:
				pic [i].GetComponent<SpriteRenderer> ().color =  new Color(1F,0F,0F,1);
				break;
			case 1:
				pic[i].GetComponent<SpriteRenderer>().color = Color.blue;
				break;
			case 2:
				pic[i].GetComponent<SpriteRenderer>().color = Color.cyan;
				break;
			case 3:
				pic[i].GetComponent<SpriteRenderer>().color = new Color(0.8F,0.1F,0.1F,1);
				break;
			default:
				pic [i].GetComponent<SpriteRenderer> ().color = Color.green;
				break;
			}
		}
		Debug.Log (values[0]+" "+values[1]+" "+values[2]+" "+values[3]);
	}
}
