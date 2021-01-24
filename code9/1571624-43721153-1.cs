    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class textureChange : MonoBehaviour {
    
        public Texture[] texture; //set in inspector
        public int currentTexture; //set default/starting index in inspector
        bool shouldChange = false; //this bool is set to prevent unwanted texture changes to the same texture every frame
    
        // Use this for initialization
        void Start()
        {
            Screen.orientation = ScreenOrientation.Landscape; //your code
        }
        public void changetexture(int textureToSet)
        {
            currentTexture = textureToSet;
            shouldChange = true;
        }
        // Update is called once per frame
        void Update()
        {
            if (shouldChange)
            {
                shouldChange = false; 
                GetComponent<Renderer>().material.mainTexture = texture[currentTexture]; //set new texture
            }
        }
    }
