        SqlConnection sqlConnection1 = new SqlConnection("Data Source=[Server];Initial Catalog=MyDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from request where reqNo = '" + lbl_reqNoV.Text + "'";
            //cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            SqlDataReader DR1;
            DR1 = cmd.ExecuteReader();
            if (DR1.HasRows)
            {
                DR1.Read();
                lbl_reqNoV.Text = DR1["ReqNo"].ToString();
            }
            sqlConnection1.Close();
 
