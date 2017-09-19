using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarScript : MonoBehaviour
{

    public CanvasGroup DrumPanel, PianoPanel, GuitarPanel;
    public GameObject BeatBtn;
    public AudioClip gSample1, gSample2, gSample3, gSample4, gSample5, gSample6, gSample7, gSample8;
    bool dispDrums = true, dispPiano = false, dispGuitar = false;
    // Use this for initialization
    void Start()
    {
        //Generate Buttons
        for (int ligne = 1; ligne < 9; ligne++)
        {                //Rows
            for (int colonne = 1; colonne < 17; colonne++)
            {     //Columns
                GameObject Beat = (GameObject)Instantiate(BeatBtn, this.transform);
                Beat.name = "GuitarBeat" + ligne + "_" + colonne;
                Beat.transform.SetParent(this.transform);
                Beat.transform.position += new Vector3(25 * colonne, -25 * ligne, 0);
                switch (ligne)
                {
                    case 1:     //Sample for row 1
                        Beat.GetComponent<BeatClass>().sample = gSample1;
                        //Debug.Log(Beat.GetComponent<BeatClass>().sample);
                        break;
                    case 2:     //Sample for row 2
                        Beat.GetComponent<BeatClass>().sample = gSample2;
                        break;
                    case 3:     //Sample for row 3
                        Beat.GetComponent<BeatClass>().sample = gSample3;
                        break;
                    case 4:     //Sample for row 4
                        Beat.GetComponent<BeatClass>().sample = gSample4;
                        break;
                    case 5:     //Sample for row 5
                        Beat.GetComponent<BeatClass>().sample = gSample5;
                        break;
                    case 6:     //Sample for row 6
                        Beat.GetComponent<BeatClass>().sample = gSample6;
                        break;
                    case 7:     //Sample for row 7
                        Beat.GetComponent<BeatClass>().sample = gSample7;
                        break;
                    case 8:     //Sample for row 8
                        Beat.GetComponent<BeatClass>().sample = gSample8;
                        break;
                    default:
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        //dispDrums = true;
        //dispPiano = false;
        //dispGuitar = false;
        dispGuitar = !dispGuitar;
        if (!dispGuitar)
        {
            DrumPanel.alpha = 0;
            DrumPanel.interactable = false;
            DrumPanel.blocksRaycasts = false;
        }
        else if (dispGuitar)
        {
            DrumPanel.alpha = 1;
            DrumPanel.interactable = true;
            DrumPanel.blocksRaycasts = true;
            PianoPanel.alpha = 0;
            PianoPanel.interactable = false;
            PianoPanel.blocksRaycasts = false;
            GuitarPanel.alpha = 0;
            GuitarPanel.interactable = false;
            GuitarPanel.blocksRaycasts = false;
        }
    }
}
