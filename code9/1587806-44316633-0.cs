    void showData(int index)
    {
        Connection con = new OrderManager.Connection();
        SqlDataAdapter sda = new SqlDataAdapter(".......", con.ActiveCon());
        dt = new DataTable();
        sda.Fill(dt);
        // Protect the access to the rows collection of the table...
        if(index < dt.RowsCount && index >= 0)
        {
            TxtBox_OrderID.Text = dt.Rows[index][0].ToString();
            // the code that fills the datagrid
        }
        else
        {
            // Message for your user about a record not found
        }
    }
