    public void Run()
    {
        window.Show();
        window.Focus();
        Initialize();
        isRunning = true;
        
        long limit = 1000 / 60;
        
        while (isRunning)
        {
            if (window.Focused)
            {
                timer.Restart();
                Update();
                LateUpdate();
                Render();
                while (timer.ElapsedMilliseconds < limit) {
                    Thread.Sleep(0);
                }
            }
        }
    }
    
