    public bool TryGoBack(Frame frame)
    {
        bool handled = false;
        if (frame?.CanGoBack ?? false)
        {
            handled = true;
            frame.GoBack();
        }
            
        this.UpdateBackButton(frame);
        return handled;
    }
