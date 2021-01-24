    private void ResetControls()
    {
        foreach (Control control in this.Controls)
        {
            if (control is Panel)
            {
                var panel = control as Panel;
                foreach (Control panelControl in panel.Controls)
                {
                    // Only look at controls whose names begin with 'o' or 'x'
                    if (panelControl.Name.StartsWith("o") || panelControl.Name.StartsWith("x"))
                    {
                        // Hide it if it's a label
                        if (panelControl is Label)
                        {
                            panelControl.Visible = false;
                        }
                        // Enable it if it's a button
                        else if (panelControl is Button)
                        {
                            panelControl.Enabled = true;
                        }
                    }
                }
            }                
        }
    }
