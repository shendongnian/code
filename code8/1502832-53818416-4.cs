    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using UnityEngine;
    
    public class ExecuteOnMainThread : MonoBehaviour {
    
        public readonly static ConcurrentQueue<Action> RunOnMainThread = new ConcurrentQueue<Action>();
            
        void Update()
        {
            if(!RunOnMainThread.IsEmpty())
            {
               while(RunOnMainThread.TryDequeue(out action))
               {
                 action.Invoke();
               }
            }
        }
    
    }
