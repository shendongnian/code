    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TestCoroutine : MonoBehaviour {
    
    
        private bool GLOBAL_LOCK = true;
        // keep a copy of the executing script
        private IEnumerator coroutine;
        public IEnumerator workCoroutine()
        {
            int i = 0;
    
            while (i <= 10)
            {            
                    Debug.Log(i);
                    i++;
                    yield return null;
            }
        }
        // Use this for initialization
        void Start () {
            StartCoroutine(workCoroutine());
        }
        void Update() {
            if (GLOBAL_LOCK )//your specific condition
            {
            StopCoroutine(coroutine);
            
            }
        }
    }
