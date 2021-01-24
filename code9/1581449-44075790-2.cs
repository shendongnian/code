    protected void ButtonSave_Click(object sender, EventArgs e) {
        int RowsAffected;
        string connstring = ConfigurationManager.ConnectionStrings["TheQuizConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connstring)) {
            string sqlcmd = "usp_QuestionAnswerAddusp_QuestionAnswerAdd";
            SqlCommand cmd = new SqlCommand(sqlcmd, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Paramaters.AddWithValue("@qID", (int)TTextBoxQid.Text);
            cmd.Paramaters.AddWithValue("@Answer", TextBoxAnswer.Text);
            cmd.Paramaters.AddWithValue("@CorrectAnswer", string.Empty); // didnt see a value for this
            try {
                connection.Open();
                RowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                RowsAffected = -1;
                // add error handling
            }
            finally { connection.Close(); }
        }
        /*
            RowsAffected should be equal to 1.
            -1 would mean there was an C# exception
            Any other failure would be in SQL commands
        */
        Response.Redirect("AddAnswer.aspx");
    }    
