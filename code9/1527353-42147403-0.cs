    public void txtbox1_TextChanged(object sender, EventArgs e)
    {
        int number;
        if (!Int32.TryParse(txtbox1.Text, out number))
        {
            MessageBox.Show("Number is invalid");
        }
        if (number == 2112)
        {
            this.BackColor = Color.Blue;
            return;
        }
        this.BackColor = Color.HotPink;
    }
