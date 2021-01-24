    using (SqlDataReader reader = command.ExecuteReader())
    {
        if (reader.FieldCount == 1)
            MessageBox.Show("Order open");
        else
        {
            while(reader.Read())
            {
               // String OrderCustommerName = reader.GetString(3).TrimEnd();
               // String OrderCustommerCity= reader.GetString(4).TrimEnd();
               // lbOrderData.Text = OrderCustommerName + " " + OrderCustommerCity;
            }
        }
    }
