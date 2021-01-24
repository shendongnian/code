    private void SetupProgress()
            {
    
                Invoke((MethodInvoker) delegate
                {
                    lblStep1.Image = global::animation1.Properties.Resources.animation;
                });
    
            }
     private Thread TDoSomeWork()
            {
                var t = new Thread(() => DoSomeWork());
                t.Start();
                return t;
            }
    TDoSomeWork();
