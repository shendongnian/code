        protected void Page_Load(object sender, EventArgs e)
        {
            long QuestionID = -1;
            //check if the Id QueryString exists
            if (Request.QueryString["Id"] != null)
            {
                //try to convert to int64
                try
                {
                    QuestionID = Convert.ToInt64(Request.QueryString["Id"]);
                }
                catch
                {
                }
            }
            //if valid QuestionID
            if (QuestionID >= 0)
            {
                using (SqlConnection connection = new SqlConnection(Common.connectionString))
                using (SqlCommand command = new SqlCommand("QuestionDetail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@QuestionID", SqlDbType.BigInt).Value = QuestionID;
                    //try to execute the stored procedure
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //handle sql error
                        Literal1.Text = ex.Message;
                    }
                }
            }
        }
