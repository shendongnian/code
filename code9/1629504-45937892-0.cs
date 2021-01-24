    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor.Animations;
    using UnityEngine;
    
    public class SwitchAnimations : MonoBehaviour
    {
        private Animator animator;
        private static UnityEditor.Animations.AnimatorController controller;
        private AnimatorState[] states;
    
        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            states = GetStateNames(animator);
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(QueueAnim(states));
            }
        }
    
        private static UnityEditor.Animations.AnimatorState[] GetStateNames(Animator animator)
        {
            controller = animator ? animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController : null;
            return controller == null ? null : controller.layers.SelectMany(l => l.stateMachine.states).Select(s => s.state).ToArray();
        }
    
        IEnumerator QueueAnim(params AnimatorState[] anim)
        {
            int index = 0;
    
            while (index < anim.Length)
            {
                if (index == anim.Length)
                    index = 0;
    
                animator.Play(anim[index].name);
    
                AnimatorStateInfo si = animator.GetCurrentAnimatorStateInfo(index);
                yield return new WaitForSeconds(5);
                index++;
            }
        }
    
        private void RollSound()
        {
    
        }
    
        private void CantRotate()
        {
    
        }
    
        private void EndRoll()
        {
    
        }
    
        private void EndPickup()
        {
    
        }
    }
