		DataTable RemoteLinks = new DataTable();
		using (SqlConnection conn = new SqlConnection(strConn)) {
			conn.Open();
			using (SqlCommand cmd = new SqlCommand("lsp_GetRemoteLinks", conn)) {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 120;
				RemoteLinks.Load(cmd.ExecuteReader());
			}
			conn.Close();
		}
