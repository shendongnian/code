    public bool IsCompactOverlayButtonVisible
    {
    
        get
        {
            return _compactOverlayButton != null
                && _compactOverlayButton.Visibility == Visibility.Visible;
        }
        set
        {
            if (_compactOverlayButton != null)
            {
                compactOverlayButton.Visibility = value 
                                                    ? Visibility.Visible
                                                    : Visibility.Collapsed;
            }
        }
    }
