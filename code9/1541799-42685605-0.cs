    public void ButtonDoWork_Click(eventArgs......) {
        DoWorkThread = new Thread(new ThreadStart(DoWork)); // Setup thread
        DoWorkThread.isBackground = true; // Its background so, we need to set background flag
        DoWorkThread.Start(); // Start the thread
    }
    
    private Thread DoWorkThread: // our Thread object
    private void DoWork() { // This void contains action that will be performed by thread
        //TODO: Background processing. To update UI from another thread use Control.Invoke(...)
    }
