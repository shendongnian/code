    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var selectedColumnName = comboBox1.SelectedItem as string;
                switch (selectedColumnName)
                {
                    case "ID":
                        dataGridView1.DataSource = products.OrderBy(product => product.ID).ToList();
                        break;
                    case "Name":
                        dataGridView1.DataSource = products.OrderBy(product => product.Name).ToList();
                        break;
                    case "Category":
                        dataGridView1.DataSource = products.OrderBy(product => product.Category).ToList();
                        break;
                    case "Price":
                        dataGridView1.DataSource = products.OrderBy(product => product.Price).ToList();
                        break;
                }
            }
        }
