    string connectionString =  "Data Source=localhost;Initial Catalog=DB_SACC;User id=sa;Password=1234;";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string textt = " USE [DB_SACC] SELECT AVG (Total_Divida) FROM t_pagamentos";
        using (SqlCommand cmd = new SqlCommand(textt, connection))
        {
            connection.Open();
            var result =  cmd.ExecuteScalar(); //write the result into a variable
            if (result == null)
            {
                MessageBox.Show("nothing");
            }
            else
            {
                TextBox3.Text = result.ToString();
            }
        }
    }
