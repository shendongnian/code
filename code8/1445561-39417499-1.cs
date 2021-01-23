     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                List<string> values = (List<string>)comboBox2.DataSource;
                values = items.Where(x => x != comboBox1.SelectedItem.ToString()).ToList();
                comboBox2.DataSource = values;
            }
