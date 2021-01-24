    connection.Open();
    for (int i = 0; i < lst_OrderName.Items.Count; i++)
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.Add("@OrderName", SqlDbType.NVarChar).Value = OrderName;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = Convert.ToInt32(lst_QTY.GetSelected(i));
            command.Parameters.Add("@Price", SqlDbType.Money).Value = Convert.ToDouble(lst_Price2.GetSelected(i));
            command.ExecuteNonQuery();
        }
    }
