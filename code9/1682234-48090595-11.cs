    private void importCSVDataFile(string filepath)
        {
            try
            {
                TextFieldParser csvreader = new TextFieldParser(filepath);
                csvreader.SetDelimiters(new string[] { "," });
                csvreader.ReadFields();
                while (!csvreader.EndOfData)
                {
                    string[] fielddata = csvreader.ReadFields();
                    var product = new Product();
                    product.ID = Convert.ToInt32(fielddata[0]);
                    product.Name = fielddata[1];
                    product.Category = fielddata[2];
                    product.Price = Convert.ToDouble(fielddata[3]);
                    products.Add(product);
                }
                dataGridView1.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import CSV File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
