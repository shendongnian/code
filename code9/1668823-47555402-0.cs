     int items;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * from scSprint",con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label1.Text = "The total is " + dr["scsprinttotal"].ToString(); 
                items = Convert.ToInt32(dr["scsprinttotal"].ToString());
            }
            con.Close();
            for (int i = 1; i <= items;i++ )
            {
                DropDownList1.Items.Add(i.ToString());
            }
        }
