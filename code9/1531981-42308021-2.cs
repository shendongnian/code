    private void numAge_ValueChanged(object sender, EventArgs e)
        {
            if (numAge.Value > 0 && numAge.Value < 13)
            {
                // Child
                // Highlight label
            }
            else if (numAge.Value > 12 && numAge.Value < 16)
            {
                // Pre-Teen
                // Highlight label
            }
            else if (numAge.Value > 15 && numAge.Value < 19)
            {
                // Teen
                // Highlight label
            }
            else if (numAge.Value > 18)
            {
                // Adult
                // Highlight label
            }
            else
            {
                // Clear the highlights
            }
        }
