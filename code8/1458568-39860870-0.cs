    using UnityEngine;
    using UnityEngine.Networking;
    using System.Collections;
    public class Object_ColorSync : NetworkBehaviour {
	[SyncVar (hook = "OnColorChange")] Color newColor;
	private Color currentColor;
	void OnColorChange(Color _myColor) {
	
		gameObject.GetComponent<Renderer> ().material.color = _myColor;
		currentColor = _myColor;
	}
	void Update () {
		if (!hasAuthority)
			return;
		if (currentColor != gameObject.GetComponent<Renderer> ().material.color) {
			Cmd_DoColor (gameObject.GetComponent<Renderer> ().material.color);
		}
	}
	[Command]
	void Cmd_DoColor(Color _theColor) {
		newColor = _theColor;
	}
    }
