    private void btnSend_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrWhitespace(txtBoxToEmail.Text))
        {
            MessageBox.Show("To can't be empty!","Invalid Address",
                            MessageBoxButtons.OK,MessageBoxIcon.Error);
            return;
        }
    ...
