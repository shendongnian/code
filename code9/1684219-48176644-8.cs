    public class UserRepository : IUserRepository
    {
    	public User GetByPendingUserId(int a_PendingUserId)
    	{
    		User l_User = new User();
    		SqlConnection l_conn = DbHelp.CreateSqlConnection();
    		SqlCommand l_cmd = DbHelp.CreateCommand(l_conn, "User_Get");
    		l_cmd.Parameters.AddWithValue("@a_PendingUserId", a_PendingUserId);
    		DataTable l_result = new DataTable();
    		SqlDataAdapter l_adapter = new SqlDataAdapter(l_cmd);
    		l_conn.Open();
    		l_adapter.Fill(l_result);
    		l_conn.Close();
    		l_adapter.Dispose();
    		l_cmd.Dispose();
    		if (l_result.Rows.Count > 0)
    		{
    			User.SetMembers(l_result.Rows[0], l_User);
    		}
    		return l_User;
    	}
    }
