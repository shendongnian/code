    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Test : MonoBehaviour {
	public Dictionary<string, AudioSource> AudioDictionary = new Dictionary<string, AudioSource>() ;
	private List<AudioSource> resAudioSource = new List<AudioSource>();
	private const string ResourcePath = "Audio/";
	public static Test instance;
	private void Awake()
	{
		#region instance
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		#endregion
		AudioClip[] resAudio = Resources.LoadAll<AudioClip>(ResourcePath);
		AudioSource temp;
		for (int audioNum = 0; audioNum < resAudio.Length; audioNum++)
		{
			temp = gameObject.AddComponent<AudioSource>();
			Debug.Log(resAudio[audioNum].name);
			AudioDictionary.Add(resAudio[audioNum].name, temp);
		}
	}
    }
