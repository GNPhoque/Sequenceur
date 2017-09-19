using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SeqPanel : MonoBehaviour
{
    GameObject DrumsPanel, PianoPanel, GuitarPanel;
    public Slider volSlider;
    public InputField BPM;
    public GameObject BeatBtn;
	public AudioSource Audio;
	public float bpm=60;
	bool playPause=false;
	public AudioClip sample1, sample2, sample3, sample4, sample5, sample6, sample7, sample8;
    int colonne = 1;

	// Use this for initialization
	public void Start ()
    {
        //Generate Buttons
		//for (int ligne = 1; ligne < 9; ligne++) {                //Rows
		//	for (int colonne = 1; colonne < 17; colonne++) {     //Columns
		//		GameObject Beat = (GameObject)Instantiate (BeatBtn, this.transform);
		//		Beat.name = "Beat" + ligne+"_"+colonne;
		//		Beat.transform.position += new Vector3 (25*colonne, -25*ligne, 0);
  //              switch (ligne)
  //              {
  //                  case 1:     //Sample for row 1
  //                      Beat.GetComponent<BeatClass>().sample = sample1;
  //                      Debug.Log(Beat.GetComponent<BeatClass>().sample);
  //                      break;
  //                  case 2:     //Sample for row 2
  //                      Beat.GetComponent<BeatClass>().sample = sample2;
  //                      break;
  //                  case 3:     //Sample for row 3
  //                      Beat.GetComponent<BeatClass>().sample = sample3;
  //                      break;
  //                  case 4:     //Sample for row 4
  //                      Beat.GetComponent<BeatClass>().sample = sample4;
  //                      break;
  //                  case 5:     //Sample for row 5
  //                      Beat.GetComponent<BeatClass>().sample = sample5;
  //                      break;
  //                  case 6:     //Sample for row 6
  //                      Beat.GetComponent<BeatClass>().sample = sample6;
  //                      break;
  //                  case 7:     //Sample for row 7
  //                      Beat.GetComponent<BeatClass>().sample = sample7;
  //                      break;
  //                  case 8:     //Sample for row 8
  //                      Beat.GetComponent<BeatClass>().sample = sample8;
  //                      break;
  //                  default:
  //                      break;
  //              }
                StartCoroutine(maCoroutine(sample1, sample2, sample3, sample4, sample5, sample6, sample7, sample8));
  //          }
		//}
	}
	
    IEnumerator maCoroutine(AudioClip sample1, AudioClip sample2, AudioClip sample3, AudioClip sample4, AudioClip sample5, AudioClip sample6, AudioClip sample7, AudioClip sample8)
    {
        while (playPause)
        {
            for (int ligne = 1; ligne < 9; ligne++)     //for each line
            {
                GameObject btnd = GameObject.Find("DrumBeat" + ligne + "_" + colonne);   //find current button
                Debug.Log(btnd.name);
                if (btnd.GetComponent<Image>().color == Color.blue)      //if selected
                {
                    Audio.PlayOneShot(btnd.GetComponent<BeatClass>().sample);    //play sample
                    Debug.Log(btnd.GetComponent<BeatClass>().sample);
                }
                GameObject btnp = GameObject.Find("PianoBeat" + ligne + "_" + colonne);   //find current button
                Debug.Log(btnp.name);
                if (btnp.GetComponent<Image>().color == Color.blue)      //if selected
                {
                    Audio.PlayOneShot(btnp.GetComponent<BeatClass>().sample);    //play sample
                    Debug.Log(btnp.GetComponent<BeatClass>().sample);
                }
                GameObject btng = GameObject.Find("GuitarBeat" + ligne + "_" + colonne);   //find current button
                Debug.Log(btng.name);
                if (btng.GetComponent<Image>().color == Color.blue)      //if selected
                {
                    Audio.PlayOneShot(btng.GetComponent<BeatClass>().sample);    //play sample
                    Debug.Log(btng.GetComponent<BeatClass>().sample);
                }
            }
            colonne++;          //for each column
            if (colonne>= 17)
            {
                colonne = 1;
            }
            yield return new WaitForSecondsRealtime(60/bpm); // and repeat every 60/bpm seconds
        }
    }

    public void OnValueChanged()        //on slider position change
    {
        Audio.volume = volSlider.value; //adjust volume accordingly
    }

    public void OnEndEdit(string edit)  //when bpm is input
    {
        bpm = (float.Parse(BPM.text));  //set bpm
    }

    public void OnClick(){              //when we click the Play/Pause button
		playPause = !playPause;
		if (playPause) {                //if paused, start playing
            StartCoroutine(maCoroutine(sample1, sample2, sample3, sample4, sample5, sample6, sample7, sample8));
        }
        else
        {                               //else (if playing then) stop playing
            StopAllCoroutines();
        }
	}
}
