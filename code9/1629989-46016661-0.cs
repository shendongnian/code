    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Microsoft.Samples.SqlServer
    {
        public class SessionStats
        {
            public long Reads { get; set; }
            public long Writes { get; set; }
            public long CpuTime { get; set; }
            public long RowCount { get; set; }
            public long WaitTime { get; set; }
            public string LastWaitType { get; set; }
            public string Status { get; set; }
    
            public override string ToString()
            {
                return $"Reads {Reads}, Writes {Writes}, CPU {CpuTime}, RowCount {RowCount}, WaitTime {WaitTime}, LastWaitType {LastWaitType}, Status {Status}";
            }
        }
        public class SqlCommandWithProgress
        {
    
    
            public static async Task ExecuteNonQuery(string ConnectionString, string Query, Action<SessionStats> OnProgress)
            {
                using (var rdr = await ExecuteReader(ConnectionString, Query, OnProgress))
                {
                    rdr.Dispose();
                }
            }
    
            public static async Task<DataTable> ExecuteDataTable(string ConnectionString, string Query, Action<SessionStats> OnProgress)
            {
                using (var rdr = await ExecuteReader(ConnectionString, Query, OnProgress))
                {
                    var dt = new DataTable();
    
                    dt.Load(rdr);
                    return dt;
                }
            }
    
    
            public static async Task<SqlDataReader> ExecuteReader(string ConnectionString, string Query, Action<SessionStats> OnProgress)
            {
                var mainCon = new SqlConnection(ConnectionString);
                using (var monitorCon = new SqlConnection(ConnectionString))
                {
                    mainCon.Open();
                    monitorCon.Open();
    
    
    
                    var cmd = new SqlCommand("select @@spid session_id", mainCon);
                    var spid = Convert.ToInt32(cmd.ExecuteScalar());
    
                    cmd = new SqlCommand(Query, mainCon);
    
                    var monitorQuery = @"
    select s.reads, s.writes, r.cpu_time, s.row_count, r.wait_time, r.last_wait_type, r.status
    from sys.dm_exec_requests r
    join sys.dm_exec_sessions s 
      on r.session_id = s.session_id
    where r.session_id = @session_id";
    
                    var monitorCmd = new SqlCommand(monitorQuery, monitorCon);
                    monitorCmd.Parameters.Add(new SqlParameter("@session_id", spid));
    
                    var queryTask = cmd.ExecuteReaderAsync( CommandBehavior.CloseConnection );
    
                    var cols = new { reads = 0, writes = 1, cpu_time =2,row_count = 3, wait_time = 4, last_wait_type = 5, status = 6 };
                    while (!queryTask.IsCompleted)
                    {
                        var firstTask = await Task.WhenAny(queryTask, Task.Delay(1000));
                        if (firstTask == queryTask)
                        {
                            break;
                        }
                        using (var rdr = await monitorCmd.ExecuteReaderAsync())
                        {
                            await rdr.ReadAsync();
                            var result = new SessionStats()
                            {
                                Reads = Convert.ToInt64(rdr[cols.reads]),
                                Writes = Convert.ToInt64(rdr[cols.writes]),
                                RowCount = Convert.ToInt64(rdr[cols.row_count]),
                                CpuTime = Convert.ToInt64(rdr[cols.cpu_time]),
                                WaitTime = Convert.ToInt64(rdr[cols.wait_time]),
                                LastWaitType = Convert.ToString(rdr[cols.last_wait_type]),
                                Status = Convert.ToString(rdr[cols.status]),
                            };
                            OnProgress(result);
    
                        }
    
                    }
                    return queryTask.Result;
    
    
                }
            }
        }
    }
