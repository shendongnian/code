    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectionStr"].ConnectionString);
        SqlCommand cmd = new SqlCommand("sp_insert_signup", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = Convert.ToInt32(TextBox1.Text);
        cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50)).Value = TextBox2.Text;
        conn.Open();
        try
        {
            int isSave = cmd.ExecuteNonQuery();
            if (isSave > 0)
            {
                Response.Write("data save successfully");
            }
            else
            {
                Response.Write("data save operation failed");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            conn.Close();
            cmd.Dispose();
        }
        
    }
