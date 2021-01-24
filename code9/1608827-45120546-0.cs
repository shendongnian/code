	[TestClass]
	public class UnitTestNomenclature
	{
		[TestMethod]
		public async Task ParallelSQLMethod()
		{
			long[] keys = new long[] { 15072000173475, 15072000173571 };
			ConcurrentQueue<long> queue = new ConcurrentQueue<long>(keys);
			int connections = Math.Max(1, Environment.ProcessorCount / 2);
			Task[] tasks =
			Enumerable
			.Range(0, connections)
			.Select(i => Task.Run<Task>(() => RunConnection(i, queue)).Unwrap())
			.ToArray()
			;
			await Task.WhenAll(tasks);
		}
		public async Task RunConnection(int connection, ConcurrentQueue<long> queue)
		{
			using (SqlConnection conn = new SqlConnection(@"data source=SERVER;initial catalog=Db;integrated security=True;Trusted_Connection=Yes;"))
			{
				await conn.OpenAsync();
				Debug.WriteLine($"====== Connection[{connection}] is open: ======");
				Debug.WriteLine($"Connection[{connection}]: {conn.ClientConnectionId}");
				Debug.WriteLine($"Connection[{connection}].State: {conn.State}");
				long scollNumbParam;
				while (queue.TryDequeue(out scollNumbParam))
				{
					await RunStoredProc(conn, connection, scollNumbParam);
					Debug.WriteLine($"Connection[{connection}]: {conn.ClientConnectionId}");
					Debug.WriteLine($"Connection[{connection}].State: {conn.State}");
				}
			}
			Debug.WriteLine($"====== Connection[{connection}] is closed  ======");
		}
		public async Task RunStoredProc(SqlConnection conn, int connection, long scollNumbParam)
		{
			const string strStoredProcName = @"[dbo].[sp]";
			using (SqlCommand cmd = new SqlCommand(strStoredProcName, conn) { CommandTimeout = 120, CommandType = CommandType.StoredProcedure })
			{
				SqlParameter scrParam = new SqlParameter()
				{
					ParameterName = "@KEYKRT",
					Value = scollNumbParam,
					SqlDbType = SqlDbType.BigInt
				};
				cmd.Parameters.Add(scrParam);
				Debug.WriteLine($"Connection[{connection}] Start of Proccesing: " + scollNumbParam);
				await cmd.ExecuteNonQueryAsync();
				Debug.WriteLine($"Connection[{connection}] End of Proccesing: " + scollNumbParam);
			}
		}
	}
