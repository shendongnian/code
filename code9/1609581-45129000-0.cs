    public void btnStart_Click(object sender, EventArgs e)
    {
        // Try to convert the input in an integer. If this succeed you have
        // the global variable _test_ set to converted text
        if(!Int32.TryParse(txtBoxInput.Text, out test)
            MessageBox.Show("Invalid input. Please type a number!");
        else
            tmrCountdown.Start();
    }
