using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_c : MonoBehaviour {

	// Use this for initialization
	public Text s;
	public int score_max;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		s.text = check_color.score_c.ToString(); 
		if (check_color.score_c > score_max) {
			score_max = check_color.score_c;
		}
	}
}
