    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class AnimationCamera : MonoBehaviour
    {
        public Camera animationCamera;
        public Camera mainCamera;
        Animator _anim;
        List<float> animations = new List<float>();
    
        private void Start()
        {
            animationCamera.enabled = false;
            mainCamera.enabled = true;
            _anim = GetComponent<Animator>();
    
            foreach (AnimationClip ac in _anim.runtimeAnimatorController.animationClips)
            {
                animations.Add(ac.length);
            }
        }
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                animationCamera.enabled = !animationCamera.enabled;
                mainCamera.enabled = !mainCamera.enabled;
    
                if (animationCamera.enabled)
                {
                    _anim.CrossFade("Animation_Sign", 0);
                }
                else
                {
                    _anim.CrossFade("Animation_Idle", 0);
                }
            }
        }
    
        public IEnumerator PlaySignAnimation()
        {        
            animationCamera.enabled = true;
            _anim.CrossFade("Animation_Sign", 0);
            yield return new WaitForSeconds(animations[0]);
            animationCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
