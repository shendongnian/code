    string query_select_id = "SELECT TOP 1 COLUMN12 from table1 WHERE column1=@value";
    SqlConnection con = new SqlConnection(ConString);
    int intvalue;
    try
    {
        con.Open();
        SqlCommand createCommand = new SqlCommand(query_select_id, con);
        createCommand.Parameters.Add("@value", SqlDbType.Int).Value  =Convert.ToInt32(textbox.Text);
        object result = cmd.ExecuteScalar();
        if(result == null)
        {
            textboxvalue.Text = "Result is NULL";
        }
        else
        {
            intvalue = (int) result; 
            textboxvalue.Text = intvalue.ToString();
        }
        con.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
