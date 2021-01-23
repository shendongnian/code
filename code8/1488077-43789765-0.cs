    public void Run()
    {
        window.Show();
        window.Focus();
        Initialize();
        isRunning = true;
        
        while (isRunning)
        {
            if (window.Focused)
            {
                Update();
                LateUpdate();
                Render();
                Thread.Sleep(16); // hard cap
            }
        }
    }
    
