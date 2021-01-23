	private void GetLocalData()
	{
		const string sql = @"SELECT laborer, trx_date from tbl_jobs WHERE trx_date BETWEEN @fromDate AND @toDate";
		var laborerDataTable = new DataTable();
		using (var conn = new SqliteAccess().ConnectToSqlite())
		{
			using (var cmd = new SQLiteCommand(sql, conn))
			{
				conn.Open();
				cmd.Parameters.AddWithValue("@fromDate", dtpFrom.Value.ToString("yyyy-MM-dd"));
				cmd.Parameters.AddWithValue("@toDate", dtpTo.Value.ToString("yyyy-MM-dd"));
				laborerDataTable.Load(cmd.ExecuteReader());
			}
		}
		var LabDict = laborerDataTable.AsEnumerable()
					.Select(row => laborerDataTable.Columns.Cast<DataColumn>()
							.ToDictionary(column => row[laborer] as string
							 			  column => row[trx_date] as string))
	}
