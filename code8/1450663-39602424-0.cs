    private void textBox1_Leave(object sender, EventArgs e)
    {
        int RegionIDInput;
        if (int.TryParse(textBox1.Text, out RegionIDInput))
        {
            if (RegionIDInput < 1 || RegionIDInput > 254)
            {
                MessageBox.Show("Enter valid value");
                this.ActiveControl = textBox1;
            }
            else
            {
                this.textBox2.Enabled = true;
            }
        }
        else
        {
            MessageBox.Show("Enter Numeric Value");
            this.ActiveControl = textBox1;
        }
    }
