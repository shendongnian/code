    private bool _isPaused = false;
    
    ctor() 
    {
        InitializeComponent();
        DoLooping();
    }
    
    private void DoLooping()
    {
        // This will keep looping forever
        while (true)
        {
            if (!_isPaused)
            {
                // do things here if not paused...
            }
        }
    }
    
    void PauseTap(object sender, EventArgs args) 
    {       
        _isPaused = !_isPaused; // This will allow the pause button to act as a toggle
    }
