    private void textBox1_Leave(object sender, EventArgs e)
    {
        int RegionIDInput;
        if (int.TryParse(textBox1.Text, out RegionIDInput))
        {
            if (RegionIDInput > 254 || RegionIDInput < 1)
            {
                MessageBox.Show("Enter valid value");
                this.ActiveControl = textBox1;
            }
        }
        else
        {
            MessageBox.Show("Enter Numeric Value");
            this.ActiveControl = textBox1;
        }
    }
