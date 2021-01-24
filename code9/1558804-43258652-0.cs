    private void btnOK_Click(object sender, EventArgs e)
    {
        _dCornerRadius = 0.0;
        bool bIsDouble = false;
    
        bIsDouble = Double.TryParse(textBoxRadius.Text, out _dCornerRadius);
    
        if (!bIsDouble || _dCornerRadius < 0.0 || _dCornerRadius > 100.0)
        {
            MessageBox.Show("Please input a radius value of 0 to 100!");
            this.DialogResult = DialogResult.None;
        }
    }
