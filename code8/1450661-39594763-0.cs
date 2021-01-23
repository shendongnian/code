    private void NameVal_Leave(object sender, EventArgs e)
    {
        int RegionIDInput;
        if (int.TryParse(textBox1.Text, out RegionIDInput))
        {
            if (RegionIDInput > 254 || RegionIDInput < 1)
            {
                MessageBox.Show("Enter valid value");
            }
        }
        else
        {
            MessageBox.Show("Enter Numeric Value");
        }
    }
