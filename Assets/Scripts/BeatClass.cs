using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatClass : MonoBehaviour {

    public AudioClip sample;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool ticked = false;

	public void OnClick(){
		ticked = !ticked;
        
		//Debug.Log (this.transform.name+" "+ticked);
		if (ticked) {
			this.GetComponent<Image>().color = Color.blue;
		} else {
			this.GetComponent<Image> ().color = Color.white;
		}

	}
}
