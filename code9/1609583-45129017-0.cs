    public void btnStart_Click(object sender, EventArgs e)
    {
        int test = 0;
        if (int.TryParse(txtBoxInput.Text, out test)) {
          //TODO: you, probably want to use parsed "test" value somehow
         
          tmrCountdown.Start();
        }
        else {
          if (txtBoxInput.CanFocus)
            txtBoxInput.Focus();
          MessageBox.Show($"'{txtBoxInput.Text}' is not a valid integer value", 
                          Application.ProductName, 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Warning);     
        }
    }
