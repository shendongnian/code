    protected override void OnElementChanged(VisualElementChangedEventArgs e)
    {
        base.OnElementChanged(e);
        if (Control != null)
        {
            Control.Style = (Style)Application.Current.Resources["DefaultPivotStyle"];      
        }
    }
