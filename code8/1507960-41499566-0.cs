    if(string.IsNullOrEmpty(txtEYear.Text))
        {
           MessageBox.Show("Please fill in the missing fields");
           txtEYear.Focus();
        }else if(string.IsNullOrEmpty(txtECat.Text))
        {
           MessageBox.Show("Please fill in the missing fields");
           txtECat.Focus();
        }else if(string.IsNullOrEmpty(txtEID.Text))
        {
           MessageBox.Show("Please fill in the missing fields");
           txtEID.Focus();
        }
