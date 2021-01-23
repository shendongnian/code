    protected void Page_PreRender(object sender, EventArgs e)
    {                        
        String sql = "exec dbo.spLoadCandidates @NationalID, @PostID";
        using (SqlCommand cmd = new SqlCommand(sql, conn)) 
        {
            cmd.Parameters.AddWithValue("@NationalID",TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@PostID,", DropDownList1.SelectedValue);
            conn.Open();
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                Repeater1.DataSource = reader;
                Repeater1.DataBind();                
            };
            conn.Close();
        }
    }
