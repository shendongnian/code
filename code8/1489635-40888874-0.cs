            SqlConnection con = new SqlConnection("=");
            con.Open();
            string query = "select ID,NAME from dbo.report";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda;
            DataSet ds = new DataSet();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            checkedListBox1.DataValueField = "ID" 
            checkedListBox1.DataTextField = "NAME"
            checkedListBox1.DataSource = ds.Tables[0];
            checkedListBox1.DataBind();
