    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    cstTxtBox.Text = string.Empty;
                }
                else
                {
                    Customer c=(Customer) comboBox1.SelectedValue;
                    cstTxtBox.Text = c.whatyouwant....
                }
