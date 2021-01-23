    using UnityEngine;
    using System.Collections;
    [RequireComponent(typeof(SpriteRenderer))]
    public class FadeOut : MonoBehaviour {
        SpriteRenderer sprRender;
        void Start()
        {
            sprRender = GetComponent<SpriteRenderer>();
        }
        void Update()
        {
            sprRender.color -= new Color(0, 0, 0, Time.deltaTime);
        }
    }
