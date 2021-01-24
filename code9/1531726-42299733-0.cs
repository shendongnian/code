    private void TrackBarsValueChanged(object sender, EventArgs e)
    {
        TrackBar clickedBar = sender as TrackBar;
        if (clickedBar == null) return;
        if (!trackBarValues.ContainsKey(clickedBar))
            trackBarValues[clickedBar] = clickedBar.Value;
        if (Math.Abs(trackBarValues[clickedBar] - clickedBar.Value) > clickedBar.LargeChange)
        {
            // yes, it was a big change
        }
        // store the current value
        trackBarValues[clickedBar] = clickedBar.Value;
    }
