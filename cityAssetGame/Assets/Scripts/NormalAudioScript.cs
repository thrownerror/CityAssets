using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAudioScript : MonoBehaviour {

	public AudioSource MusicSource;

	public AudioClip[] MusicClips;

	// Use this for initialization
	void Start () 
	{
		MusicSource.clip = MusicClips [0];	
	}

	// Update is called once per frame
	void Update () 
	{
	}

	public void SoundChange(int temp)
	{
		MusicSource.clip = MusicClips [temp];

		MusicSource.Play ();	
	}
}
