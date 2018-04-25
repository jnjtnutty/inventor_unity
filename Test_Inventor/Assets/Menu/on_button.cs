using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class on_button : MonoBehaviour {

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
		string input = stream_open.stream.ReadLine ();
		if (input == "A") {
			OnPointerClick ();
			mode.name = "A";
		}
		else if (input == "B") {
			OnPointerClick ();
			mode.name = "B";
		}
		if(count_a >= 7)
		{
			SceneManager.LoadScene("color");
		}
		if(count_b >= 7)
		{
			SceneManager.LoadScene("word");
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

	public void OnPointerClick()
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
