    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Sign_Wooden_Blank : Interactable
    {
        public override void Interact()
        {
            var ac = GameObject.Find("AnimationCamera").GetComponent<AnimationCamera>();
            ac.StartCoroutine(ac.PlaySignAnimation());
        }
    }
