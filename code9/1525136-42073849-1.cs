    public void RefreshLayout()
    {
        int offset;
        if (buttonDown.Visible)
        {
            // The button is visible
            offset = buttonDown.Height;
        } 
        else
        {
            // The button is hidden
            offset = buttonDown.Height * -1;
        }
        // For each control under the button...
        control1.Location.Y = control1.Location.Y + offset;
        control2.Location.Y = control2.Location.Y + offset;
        // and so forth, for each control
    }
