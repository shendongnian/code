    protected void btnSave_Click(object sender, EventArgs e)
    {
        var id = GridView2.SelectedDataKey.Values[0].ToString();
        string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open(); // actually connect to the server
            string query = "UPDATE user SET place= @place where ID = @ID "; // change @D to @ID
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@place", txtPlace.Text);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery(); // actually execute your statement
            }
        }
    }
