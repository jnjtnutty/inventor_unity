using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO.Ports;

public class on_button : MonoBehaviour ,IPointerClickHandler{

	// Use this for initialization
	//public string scene;
	public Transform bar;
	private float currentAmount;
	public float speed;
	public GameObject mode;
	public int count_a;
	public int count_b;

	void Start () {
		
	}
	void Update()
	{
		if (stream_open.stream.IsOpen) {
			try {
				string input = stream_open.stream.ReadLine().ToString ();
				if (input == "A") {
					print(input);
					//mode.name = "A";
					stream_open.stream.Write ("colors");
					SceneManager.LoadScene ("color");
					//OnPointerClick (pointerEventData);
				} else if (input == "B") {
					print(input);
					stream_open.stream.Write ("words");
					SceneManager.LoadScene ("word");
					//mode.name = "B";
					//OnPointerClick ();
				}
				/*if (count_a >= 7) {
					stream_open.stream.Write ("colors");
					string value = stream_open.stream.ReadLine ();
					Debug.Log (value);
					SceneManager.LoadScene ("color");

				}
				if (count_b >= 7) {
					stream_open.stream.Write ("words");
					string value = stream_open.stream.ReadLine ();
					Debug.Log (value);
					SceneManager.LoadScene ("word");
				}*/
			} catch (System.Exception) {
				throw;
			}
		}
	}
	public void OnPointerEnter()
	{
		//If your mouse hovers over the GameObject with the script attached, output this message
	}

	public void OnPointerExit()
	{
		//The mouse is no longer hovering over the GameObject so output this message each frame
	
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (currentAmount < 100) {
			currentAmount += speed * Time.deltaTime;
		}
		if (mode.name == "A") {
			count_a += 1;
		}
		if (mode.name == "B") {
			count_b += 1;
		}
		bar.GetComponent<Image> ().fillAmount = currentAmount ;
	}

}
