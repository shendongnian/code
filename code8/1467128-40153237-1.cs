    protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void InsertValue(string value)
        {
            using (SqlConnection con = new SqlConnection("YOUR_CONNECTION_STRING")) //Creating connection object
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO YOUR_TABLE_NAME (Field_Name) VALUES (@value)", con))
                    {
                        if (con.State == System.Data.ConnectionState.Closed) con.Open();
                        cmd.Parameters.AddWithValue("@value", value);   // Adding parameter with value to command object
                        int result = cmd.ExecuteNonQuery();             // Executing query and it returns no of rows affected.
                        if (result > 0) Response.Write("Successful.");  // Checking if no of rows affected is > 0 meaning value successfully inserted.
                    }
                }
                catch (SqlException ex)  //Handling SQL Exceptions
                {
                    this.LogErrors(ex);
                }
            }
        }
        private void LogErrors(Exception ex)
        {
            // Write error log logic here
        }
        protected void btnInsert_Click(object sender, EventArgs e) // insert data button click event handler
        {
            this.InsertValue(this.txtValue.Text); 
        }
