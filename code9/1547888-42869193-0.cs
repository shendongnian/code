    if (IsPostBack == false){
     GridView1.Visible = false;
                /*div1.Visible = true; */
                 con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from hotels_main";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
    
                con.Close();
                book.Visible = false;
    }
