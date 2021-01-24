    public void btnStart_Click(object sender, EventArgs e)
    {
        if (int.TryParse(txtBoxInput.Text, out test)) 
          // We succeed in parsing, so we continue with the timer
          tmrCountdown.Start();
        else {
          // We failed in parsing
          // Let's put keyboard focus on the problem text box...
          if (txtBoxInput.CanFocus)
            txtBoxInput.Focus();
          // ... and report what's been happened
          MessageBox.Show($"'{txtBoxInput.Text}' is not a valid integer value", 
                          Application.ProductName, 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Warning);     
        }
    }
