    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                if (comboBox1.SelectedIndex == -1)
                {
                    cstTxtBox.Text = string.Empty;
                }
                else
                {
                foreach (var item in comboBox1.Items)
                {
                cstTxtBox.Text = cstTxtBox.Text + item.ToString();
                }
                    
                }
