    protected void Button1_Click(object sender, EventArgs e) 
     {
  
     if (Button1.ToolTip == "Insert")
            {
              //  con = your Connection String
    cmd = new SqlCommand("insert into Country1 (CountryID,Name,CountryNotes) values(@CountryID, @Name, @CountryNotes)", con);
                cmd.Parameters.AddWithValue("@CountryID", Text1.Text);
                cmd.Parameters.AddWithValue("@Name", Text2.Text);
                cmd.Parameters.AddWithValue("@CountryNotes", Text3.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (Button1.ToolTip == "Update")
            {
                int id = Convert.ToInt32(ViewState["CountryID"]);
                update(id);
            }
            clear();
        }
