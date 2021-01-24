    public void btnStart_Click(object sender, EventArgs e)
    {
        if (int.TryParse(txtBoxInput.Text, out test)) 
          tmrCountdown.Start();
        else {
          if (txtBoxInput.CanFocus)
            txtBoxInput.Focus();
          MessageBox.Show($"'{txtBoxInput.Text}' is not a valid integer value", 
                          Application.ProductName, 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Warning);     
        }
    }
