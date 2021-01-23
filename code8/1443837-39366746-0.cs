    again.CommandType =  CommandType.Text;
    again.CommandText = "INSERT INTO TestData(ColumnName1,ColumnName2) Values('" + textBox1.Text + "', '" + comboBox1.Text + "')";
                   again.Connection = test;
                    test.Open();
                    again.ExecuteNonQuery();
                    test.Close();
                    MessageBox.Show("Data Entry Successful");
