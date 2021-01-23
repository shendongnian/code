    using UnityEngine;
    using UnityStandardAssets.ImageEffects;
    
    public class MyScript : MonoBehaviour
    {
        void Start()
        {
            Bloom bloomEffect = Camera.main.GetComponent<Bloom>();
            Blur blurEffect = Camera.main.GetComponent<Blur>();
            Tonemapping toneMappingEffect = Camera.main.GetComponent<Tonemapping>();
        }
    }
