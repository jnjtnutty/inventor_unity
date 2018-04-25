using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_color : MonoBehaviour {

	// Use this for initialization
	public static int score_c = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (time_random_color.values [0] != 0 || time_random_color.values[1] !=0) {
			int red = time_random_color.values [0];
			int green = time_random_color.values [1];
			int pink = time_random_color.values [2];
			int blue = time_random_color.values [3];
			while (red != 0 && green != 0 && pink != 0 && blue != 0) {
				string input = stream_open.stream.ReadLine ();
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
				if (red == 0 && green == 0 && blue == 0 && pink == 0) {
					break;
				}
			}
		
			if (red == 0 && green == 0 && blue == 0 && pink == 0) {
				score_c += 1;
				time_random_color.random_num_func ();
				time_random_color.round = 20;
			}

		}
	}
}
