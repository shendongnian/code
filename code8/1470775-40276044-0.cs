    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            using (var con = new OleDbConnection())
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["northwind"].ToString();
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(ID) FROM Table1 WHERE pEmail= @em";
                    cmd.Parameters.AddWithValue("@em", TextBox2.Text);
                    int count = Convert.ToInt32(cmd.ExecutScalar());
                    if (count > 0)
                    {
                        Label1.Text = "email is already in use";
                    }
                    else
                    {
                        cmd.CommandText = "insert into[Table1](pName, pEmail)values(@nm, @em)";
                        cmd.Parameters.AddWithValue("@nm", TextBox1.Text);
                        // not need to add @em parameter, it was added previously
                        int insertedRows = cmd.ExecuteNonQuery();
                        if (insertedRows > 0)
                        {
                            Label1.Text = "Inserted Sucessfully!";
                        }
                    }
                }
            }
        }
    }
