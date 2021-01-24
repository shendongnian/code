    [HttpPost]
    public IHttpActionResult Post(JobConfirmation confirmation)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
        {
            string outputMessage;
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_PhoneApp_ConfirmBooking", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_jobId", confirmation.JobID);
            cmd.Parameters.AddWithValue("@p_jobStatus", confirmation.JobStatus);
            cmd.Parameters.AddWithValue("@p_createdDate", confirmation.CreatedDate);
            if(cmd.ExecuteNonQuery() > 0)
               outputMessage = "Success";
            else
               outputMessage = "Failed";
            ...
        }
    }
