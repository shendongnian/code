    using UnityEngine;
    using System.Threading;
    
    public class Test : MonoBehaviour
    {
        private Thread _thread;
        void Start()
        {
            _thread = new Thread(Run);
            _thread.Name = "DaydreamThread";
            _thread.Priority = System.Threading.ThreadPriority.BelowNormal;
            _thread.IsBackground = true;
            _thread.Start();
        }
    
        private void Run()
        {
            try
            {
                // Endless loop
                for (;;)
                {
                    // Do your stuff
                }
            }
            catch (ThreadAbortException)
            {
                // If you expect to do a Abort() on the thread then you want to
                //  ignore this exception
            }
        }
    }
