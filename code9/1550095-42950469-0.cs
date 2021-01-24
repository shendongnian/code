    protected void UsedForButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox checkbox1 = (CheckBox)row.FindControl("InStockCbx");
            if (checkbox1.Checked)
            {
                int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value.ToString());           
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                SqlCommand cmd = new SqlCommand ("UPDATE WorkTable SET InStock = 0 WHERE Id = @Id"", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
            }
        }
    }
