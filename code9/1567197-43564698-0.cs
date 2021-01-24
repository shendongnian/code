    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                if (comboBox1.SelectedIndex == -1)
                {
                    cstTxtBox.Text = string.Empty;
                }
                else
                {
                foreach (item i in comboBox1)
                {
                cstTxtBox.Text = cstTxtBox.Text + i.ToString();
                }
                    
                }
