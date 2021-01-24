    using (MySqlCommand sqlcmd = new MySqlCommand(load_temp_table_rec_qry, cnn1))
    {
        MySqlDataReader temp_reader = sqlcmd.ExecuteReader();
        using (var secondConnection = new MySqlConnection(connetionString1))
        {
            secondConnection.Open();
            while (temp_reader.Read())
            {
                string insert_invoice_items_qry = "INSERT INTO tblInvoiceItems(invoiceID, particulars, qty, rate) VALUES('" + 12 + "', '" + temp_reader["particulars"] + "', '" + temp_reader["qty"] + "', '" + temp_reader["rate"] + "')";
                using (MySqlCommand itemsCmd = new MySqlCommand(insert_invoice_items_qry, secondConnection))
                {
                    itemsCmd.ExecuteNonQuery();
                }
            }
        }
    }
