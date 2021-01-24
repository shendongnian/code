    public int[] UpdateIssueResolutionStatus(Int32 summaryId, string alerttype, string alertserver, string subject)
    {
    	int[] rowseffected;
    	string cs = ConfigurationManager.ConnectionStrings["LogsData"].ConnectionString;
    	using (SqlConnection con = new SqlConnection(cs))
    	{
    		SqlCommand cmd = new SqlCommand("spUpdateResolutionStatus", con);
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.Parameters.Add(new SqlParameter("@SummaryId", summaryId));
    		cmd.Parameters.Add(new SqlParameter("@AlertType", alerttype));
    		cmd.Parameters.Add(new SqlParameter("@AlertServer", alertserver));
    		cmd.Parameters.Add(new SqlParameter("@Subject", subject));
    		con.Open();
    		
    		using (IDataReader reader = cmd.ExecuteReader())
    		{
    			List<int> ids = new List<int>();
    			while (reader.Read())
    			{
    				ids.Add(reader.GetInt32(0));
    			}
    
    			return ids.ToArray();
    		}
    	}
    }
