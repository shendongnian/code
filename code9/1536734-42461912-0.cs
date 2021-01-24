    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class txWrap : MonoBehaviour
    {
        public List<GameObject> myGameObjects;
    
	    // Use this for initialization
	    void Awake ()
        {
            /*
             * IMPORTANT: if you use those textures' wrap mode ever again,
             * ESPECIALLY during runtime, use similar method to get the components to
             * another List, with the generic type of List<Texture>. 
             * GetComponent is slow and prone to error, use it runtime as few as possible. 
             */ 
	        foreach(var item in myGameObjects)
            {
                item.GetComponent<Texture>().wrapMode = TextureWrapMode.Repeat;
            }
	    }
    }
