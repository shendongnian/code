    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtPName.Text) || string.IsNullOrEmpty(txtAddress.Text))
        {
            MessageBox.Show("Missing Data");
            return;
        }
    // Your code here...
