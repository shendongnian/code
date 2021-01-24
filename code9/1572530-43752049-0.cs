    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TestCoroutine : MonoBehaviour {
    
    
        private bool GLOBAL_LOCK = true;
    
        public IEnumerator workCoroutine()
        {
            int i = 0;
    
            while (i <= 10)
            {
                if (GLOBAL_LOCK)
                {
                    Debug.Log(" I am in if condition");
                    Debug.Log(" will exit the coroutine");
                    yield break;
                }else{
                    Debug.Log(i);
                    i++;
                    yield return null;
                }
            }
        }
        // Use this for initialization
        void Start () {
            StartCoroutine(workCoroutine());
        }
    }
