    String sql = "exec dbo.spLoadCandidates @NationalID, @PostID";
    SqlDataReader reader;
    using (SqlCommand cmd = new SqlCommand(sql, conn)) 
    {
        cmd.Parameters.AddWithValue("@NationalID",TextBox2.Text.Trim());
        cmd.Parameters.AddWithValue("@PostID,", DropDownList1.SelectedValue);
        conn.Open();
        reader = cmd.ExecuteReader();
        while (reader.HasRows)
        {
             // Create div.
             var div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");      
            createDiv.InnerHtml = "" // Fill with your content...
            // Add to placeholder.
            PlaceHolder1.Add(createDiv);
        }
        conn.Close();
    }      
