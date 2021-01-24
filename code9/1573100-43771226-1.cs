    private void btnSubmit_Click(object sender, EventArgs e)
    {
        FillIn(txtName, txtStreetAddress, txtCity, txtState, txtZip);
    }
    private void FillIn(TextBox name, TextBox address, TextBox city, TextBox state, TextBox zip)
    {
        if (name.Text == "")
        {
            name.Text = "Bob Frank";
        }
        if (address.Text == "")
        {
            address.Text = "4111 N Pensyvania Ave.";
        }
        if (city.Text == "")
        {
            city.Text = "Longbeach";
        }
        if (state.Text == "")
        {
            state.Text = "CA";
        }
        if(zip.Text == "")
        {
            zip.Text = "99210";
        }
    }
