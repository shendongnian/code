    SqlConnection con = new SqlConnection("Data Source=.;Initial    Catalog=Sample;Integrated Security=true;");
    SqlCommand cmd;
    SqlDataAdapter adapt;
    SqlTransaction trans;
    private void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            trans = con.BeginTransaction();     // Begins transaction
            string query = "insert into users(Name,Password)values('ubaid','ali')";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            trans.Commit();
        }
        catch (Exception ex) //error occurred
        {
            trans.Rollback();  // Rollback transaction on error
        }
    }
