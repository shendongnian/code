    private void Order()
    {
        using (SqlConnection connection = new SqlConnection(connectionString1))
        {
            String query = "INSERT INTO Tbl_order (OrderName,Quantity,Price,Serves_way,Date) VALUES (@OrderName,@Quantity, @Price,'"+servers+"','" + time1.ToString(format1)+"' )";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add the length of this text column as third parameter...
                command.Parameters.Add("OrderName", SqlDbType.NVarChar);
                command.Parameters.Add("Quantity", SqlDbType.Int);
                command.Parameters.Add("Price", SqlDbType.Money);
                command.Prepare();
                for (int i = 0; i < lst_OrderName.Items.Count; i++)
                {
                    command.Parameters[0].Value = lst_OrderName.GetItemText(lst_OrderName.GetSelected(i));
                    command.Parameters[1].Value = Convert.ToInt32(lst_QTY.GetSelected(i));
                    command.Parameters[2].Value = Convert.ToDouble(lst_Price2.GetSelected(i));
                    command.ExecuteNonQuery();
                }
            }  
        }
    }
