    public class ApplicationRepository : IApplicationRepository
    {
    	public Application GetByPendingAppId(int a_PendingAppId)
    	{
    		Application l_Application = new Application();
    		SqlConnection l_conn = DbHelp.CreateSqlConnection();
    		SqlCommand l_cmd = DbHelp.CreateCommand(l_conn, "Application_Get");
    		l_cmd.Parameters.AddWithValue("@a_PendingAppId", a_PendingAppId);
    		DataTable l_result = new DataTable();
    		SqlDataAdapter l_adapter = new SqlDataAdapter(l_cmd);
    		l_conn.Open();
    		l_adapter.Fill(l_result);
    		l_conn.Close();
    		l_adapter.Dispose();
    		l_cmd.Dispose();
    		if (l_result.Rows.Count > 0)
    		{
    			Application.SetMembers(l_result.Rows[0], l_Application);
    		}
    		return l_Application;
    	}
    }
