        public class StartStop : IDisposable
        {
            public StartStop() {  Start(); }
            public void Dispose() { Stop(); }
            protected void Start() { /*...*/ }
            protected void Stop() { /*...*/ }
        }
