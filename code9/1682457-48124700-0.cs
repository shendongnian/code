    //https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseOver.html
        
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MouseOver : MonoBehaviour
    {
        public Texture TexturaSencillaBlanca;
        public Texture TexturaSencillaBlanca2;
    
        //When the mouse hovers over the GameObject, it turns to this color (red)
        Color m_MouseOverColor = Color.yellow;
        //This stores the GameObject’s original color
        Color m_OriginalColor;
        //Get the GameObject’s mesh renderer to access the GameObject’s material and color
        MeshRenderer m_Renderer;
      
        void Start()
        {
            //Fetch the mesh renderer component from the GameObject
            m_Renderer = GetComponent<MeshRenderer>();
            //Fetch the original color of the GameObject
            m_OriginalColor = m_Renderer.material.color;
        }
    
        void OnMouseOver()
        {
            Debug.Log("El color del objeto es AMARILLO.");
            //Change the color of the GameObject to red when the mouse is over GameObject
            if (m_Renderer.isVisible)
            {   //Change Color of object on mouseHover
                m_Renderer.material.color = m_MouseOverColor;
                //Load Resources directly from folder
                GetComponent<Renderer>().material.mainTexture = (Texture)Resources.Load("TexturaSencillaBlanca");
            }
        }
    
        void OnMouseExit()
        {
            Debug.Log("El color del objeto es BLANCO.");
            //Reset the color of the GameObject back to normal
            m_Renderer.material.color = m_OriginalColor;
            GetComponent<Renderer>().material.mainTexture = (Texture)Resources.Load("TexturaSencillaBlanca2");
        }
    }
