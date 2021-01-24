    private void ResetControls()
    {
        foreach (Control control in this.Controls)
        {
            // Only look at controls whose names begin with 'o' or 'x'
            if (control.Name.StartsWith("o") ||control.Name.StartsWith("x"))
            {
                // Hide it if it's a label
                if(control.GetType() == typeof(Label))
                {
                    control.Visible = false;
                }
                // Enable it if it's a button
                else if (control.GetType() == typeof(Button))
                {
                    control.Enabled = true;
                }
            }
        }
    }
