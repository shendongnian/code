    private void txtAge_TextChanged(object sender, EventArgs e)
        {
            int txtAgeValue = 0;
            if (!string.IsNullOrWhiteSpace(txtAge.Text))
            {
                txtAgeValue = int.Parse(txtAge.Text);
            }
            if (txtAgeValue < 13)
            {
                // Child
                // Highlight label
            }
            else if (txtAgeValue > 12 && txtAgeValue < 16)
            {
                // Pre-Teen
                // Highlight label
            }
            else if (txtAgeValue > 15 && txtAgeValue < 19)
            {
                // Teen
                // Highlight label
            }
            else
            {
                // Adult
                // Highlight label
            }
        }
