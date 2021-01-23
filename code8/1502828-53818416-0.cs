    using System;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ExecuteOnMainThread : MonoBehaviour {
    
        public readonly static Queue<Action> RunOnMainThread = new Queue<Action>();
            
        void Update()
        {
            while (RunOnMainThread.Count > 0)
            {
                RunOnMainThread.Dequeue().Invoke();
            }
        }
    
    }
