     private void addItem_Click(object sender, EventArgs e)
        {
            nameItem.Enabled = true;
            comboBox1.Items.Add("Item " + counter.ToString());
            comboBox1.SelectedItem = "Item " + counter.ToString();
            nameMacro.Text = "Item " + counter.ToString();
            //comboBox1.SelectedItem = nameItem.Text;
            //nameItem.Focus();
            // Ad degistirme -> comboBox1.Items[comboBox1.FindStringExact("string value")] = "New Value";
            counter++;
        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items[comboBox1.SelectedIndex] = nameItem.Text;
        }
