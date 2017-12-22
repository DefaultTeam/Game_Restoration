using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControler : MonoBehaviour {

    public AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        audio.volume = Global.music * 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
        audio.volume = Global.music * 0.3f;
    }
}
