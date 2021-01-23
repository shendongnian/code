        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=FATIMAH;Initial Catalog=Bank database;Integrated Security=True"))
            {
                string sql = "delete Account where number = @number";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@number", DropDownList3.SelectedValue);
                    comm.ExecuteNonQuery();
                }
            }
        }
