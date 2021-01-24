        private void GetData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["siecConnectionString"].ConnectionString);
            using (con)
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("NewQuery", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", lbl1.Text);
                cmd.Parameters.AddWithValue("@Desc", lbl2.Text);
                cmd.Parameters.AddWithValue("@Price", lbl3.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                decimal conversionRate = 1; // THIS IS QUERY YOU'D GET THE RATE
                foreach(DataRow row in dt.Rows)
                {
                    row["Price"] = Convert.ToDecimal(row["Price"]) * conversionRate;
                }
                rp1.DataSource = dt;
                rp1.DataBind();
            }
        }
