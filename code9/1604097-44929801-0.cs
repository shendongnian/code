    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TexturesOverWall : MonoBehaviour
    {
	private Texture2D[] walltextures;
	void Awake ()
	{
		mapTexturesOverWalls ();
	}
	void mapTexturesOverWalls ()
	{
		walltextures = Resources.LoadAll<Texture2D> ("Walls");
		GameObject walls = GameObject.FindGameObjectWithTag ("Wall");
		Renderer[] renders = walls.GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in renders) {
			// all you need to do is name each wall segmentation gameobject with the same name of the texture to apply
			r.material.mainTexture = getTextureByName(r.gameObject.name);
		}
	}
	Texture2D getTextureByName (string name)
	{
		foreach (var tex in walltextures) {
			if (tex.name == name)
				return tex;
		}
		return null;
	}
}
