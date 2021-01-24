    var scsb = new SqlConnectionStringBuilder();
    scsb.Password="....";
    scsb.UserID="sa";
    scsb.DataSource="localhost";
    scsb.InitialCatalog="test";
    using(SqlConnection conn = new SqlConnection(scsb.ConnectionString)) 
    {
        conn.Open();
        using(var tran=conn.BeginTransaction()) {
            using(var comm = new SqlCommand("DELETE FROM pf_ServiceHeartbeat WHERE ServiceName = @ServiceName AND MachineName = @MachineName", conn, tran)) {
                comm.Parameters.AddWithValue("@ServiceName", "PopForums.Email.EmailApplicationService");
                comm.Parameters.AddWithValue("@MachineName", "MACHINENAME");
                comm.ExecuteNonQuery();
                comm.CommandText="INSERT INTO pf_ServiceHeartbeat (ServiceName, MachineName, LastRun) VALUES (@ServiceName, @MachineName, @LastRun)";
                comm.Parameters.AddWithValue("@LastRun", DateTime.Now);
                comm.ExecuteNonQuery();
            }
            tran.Commit();
        }
    }
