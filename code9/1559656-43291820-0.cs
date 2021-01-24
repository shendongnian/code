    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class colourChangeArray : MonoBehaviour
    {
        public int trigger = 1;
        public Material[] material;
        Renderer rend;
        private bool changeMaterialDone;
    
        // Use this for initialization
        void Start()
        {
            rend = GetComponent <Renderer> ();
            rend.enabled = true;
            rend.sharedMaterial = material[0];
            changeMaterialDone = false;
        }
    
    
        // Update is called on collision
        void OnCollisionEnter(Collision col)
        {
            if (!changeMaterialDone && col.gameObject.tag == "box")
            {
                changeMaterialDone = true;
                for(int i = 0; i <material.Length; i++)
                {
                    rend.sharedMaterial = material[i];
                    Debug.Log(rend.sharedMaterial);
                }
            }
            else
            {
                rend.sharedMaterial = material[0];
                Debug.Log(rend.sharedMaterial);
            }
        }
    }
