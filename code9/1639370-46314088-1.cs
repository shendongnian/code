    protected void Button2_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q69PRF4;Initial Catalog=new;Integrated Security=True"))
        {
            con.Open();
            string str = "select [StID] from StRecords where StID = @stdId;";
            using (SqlCommand com = new SqlCommand(str, con))
            {
                com.Parameters.AddWithValue("@stdId", Session["login"]);
                Label11.Text = com.ExecuteScalar().ToString();
            }
        }
    }
