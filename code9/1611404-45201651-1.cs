    private void txtGuess_TextChanged(object sender, EventArgs e)
    {
        if(txtGuess.Text != null)
            guess = Convert.ToInt32(txtGuess.Text);
    }
