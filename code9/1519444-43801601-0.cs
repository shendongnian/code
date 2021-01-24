    protected override void OnSourceInitialized(EventArgs e)
    {
        // For added compatibility, turn off hardware rendering 
        HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
        HwndTarget hwndTarget = hwndSource.CompositionTarget;
        hwndTarget.RenderMode = RenderMode.SoftwareOnly;
        base.OnSourceInitialized(e);
    }
