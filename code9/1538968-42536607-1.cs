    private void control_MouseHover(object sender, EventArgs e) 
    {
        var control = (Control)sender;
        var text = toolTip1.GetToolTip(control);
        if (!string.IsNullOrEmpty(text))
            toolTip1.Show(text, control, control.PointToClient(new Point(100, 100)));
    }
    private void control_MouseLeave(object sender, EventArgs e)
    {
        var control = (Control)sender;
        toolTip1.Hide(control);
    }
