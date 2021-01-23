    private void HandlePreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.XButton1:
                NavigateBack(sender, e); // call the back button event handler
                break;
            case Keys.XButton2:
                NavigateForward(sender, e); // call the forward button event handler
                break;
        }
    }
    
    private void HandleMouseDown(object sender, MouseEventArgs e)
    {
        switch (e.Button)
        {
            case MouseButtons.XButton1:
                NavigateBack(sender, e); // call the back button event handler
                break;
            case MouseButtons.XButton2:
                NavigateForward(sender, e); // call the forward button event handler
                break;
        }
    }
