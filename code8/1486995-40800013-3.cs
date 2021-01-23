    String sql = "exec dbo.spLoadCandidates @NationalID, @PostID";
    SqlDataReader reader;
    using (SqlCommand cmd = new SqlCommand(sql, conn)) 
    {
        cmd.Parameters.AddWithValue("@NationalID",TextBox2.Text.Trim());
        cmd.Parameters.AddWithValue("@PostID,", DropDownList1.SelectedValue);
        conn.Open();
        reader = cmd.ExecuteReader();
        var list = new List<MyModel>();
        while (reader.HasRows)
        {
            var model = new MyModel();
            model.Name = "foo"; // Fill with your content...
            list.Add(model);
        }
        conn.Close();
        // Bind to repeater.
        Repeater1.DataSource = list;
        Repeater1.DataBind();
    }      
