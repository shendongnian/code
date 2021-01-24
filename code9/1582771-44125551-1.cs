    void GetOrderHead(int ID)
        {
            string[] formats= { "MM/dd/yyyy" }
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Orders WHERE OrderNo=@OrderNo";
            cmd.Parameters.AddWithValue("@OrderNo", ID);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ltID.Text = dr["OrderNo"].ToString();
                    txtOrderNo.Text = dr["OrderNo"].ToString();
                    txtDateOrdered.Text = DateTime.ParseExact(dr["DateOrdered"].ToString(), formats, new CultureInfo("en-US"), DateTimeStyles.None); //changing format.
                    txtPreparedBy.Text = dr["PreparedBy"].ToString();
                    txtStatus.Text = dr["Status"].ToString();
                    txtBalance.Text = dr["Balance"].ToString();
                    txtTotal.Text = dr["TotalAmount"].ToString();
                }
                con.Close();
            }
            else
            {
                con.Close();
                Response.Redirect("Default.aspx");
            }
        }
