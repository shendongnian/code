    // In each window class or as a base class:
    private bool isClosable = false;
    
    protected override void OnClosing(CancelEventArgs args)
    {
        // Prevent closing until allowed.
        if (!isClosable) {
            args.Cancel = true;
            Hide();
        }
        base.OnClosing(args);
    }
    
    // Call this when you want to destroy the window like normal.
    public void ForceClose()
    {
        isClosable = true;
        Close();
    }
