    using UnityEngine;
    using System.Threading;
    
    public class Test : MonoBehaviour
    {
        private Thread _thread;
        private ManualResetEvent _signal = new ManualResetEvent(false);
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
                    // Wait for a signal to do another pass
                    _signal.WaitOne();
                    _signal.Reset();
    
    
                    // Do your stuff
                }
            }
            catch (ThreadAbortException)
            {
                // If you expect to do a Abort() on the thread then you want to
                //  ignore this exception
            }
        }
    
        void Update()
        {
            if (something)
                // Signal Run-thread to do another pass
                _signal.Set();
        }
    }
