    public class MyLooper
    {
        private bool KeepLooping { get; set; } = true;
        public void OnKeyPressed()
        {
            KeepLooping = false;
        }
        public void StartLoop()
        {
            Task.Factory.StartNew(() => {
                while (KeepLooping)
                {
                    Debug.WriteLine("Hello World");
                }
            });
        }
    }
