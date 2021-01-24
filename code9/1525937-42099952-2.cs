    using System;
    using UnityEngine;
    
    namespace Assets.Scripts
    {
        public class Player : MonoBehaviour
        {
            public GameManager GameManager; // TODO assign this in Inspector
    
            public void Start()
            {
                if (GameManager == null)
                    throw new InvalidOperationException("TODO");
            }
    
            public void Update()
            {
                // demo
                var wounded = true;
                var woundedAudioClip = new AudioClip();
                if (wounded)
                {
                    GameManager.PlayAudioClip(woundedAudioClip);
                }
            }
        }
    }
