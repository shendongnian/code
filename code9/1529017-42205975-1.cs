    public void ResetAllTextBoxes()
    {
        // Iterate over all Controls in the current form
        foreach (Control control in this.Controls)
            // If the control is a TextBox ...
            if (control is TextBox)
                // ... clear its text
                (control as TextBox).Text = "";
    }
