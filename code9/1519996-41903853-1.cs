    private void CustomersBindGrid()
    {
        using (SqlConnection con = new SqlConnection(mycon))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM Customers";
                cmd.Connection = con;
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    Gridview1.DataSource = dt;
                    Gridview1.DataBind();
                }
            }
            con.Close();
        }
    }
