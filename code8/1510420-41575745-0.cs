     private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("NULL");
            }
            else
            {    
                label2.Text = comboBox2.SelectedValue.ToString();
            }
       }
