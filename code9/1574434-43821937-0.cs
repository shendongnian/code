         private void Search_btn_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "Select * from BookInTable where Barcode = '" + Barcode_txtBx.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            
            DataTable dt = new DataTable();
          
            dt.Load(reader);
            string data = dt.ToString();
          
            Manufacturer_txtBx.Text = dt.Rows[0].ItemArray[5].ToString();
            Type_txtBx.Text = dt.Rows[0].ItemArray[6].ToString();
            Model_txtBx.Text = dt.Rows[0].ItemArray[7].ToString();
            PartNumber_txtBx.Text = dt.Rows[0].ItemArray[8].ToString();
            AdditionalDetails_txtBx.Text = dt.Rows[0].ItemArray[13].ToString();
            connection.Close();
        }
