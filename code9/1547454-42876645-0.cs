    public class RolesHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            context.Response.Write(GetData());
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public string GetData()
        {
            var result = string.Empty;
            var con = new SqlConnection();
            var cmd = new SqlCommand();
            var dt = new DataTable();
            string sSQL = @"SELECT Id, Name
                            FROM dbo.AspNetRoles;";
            try
            {
                using (var connection = THF.Models.SQLConnectionManager.GetConnection())
                {
                    using (var command = new SqlCommand(sSQL, connection))
                    {
                        connection.Open();
                        command.CommandTimeout = 0;
                        var da = new SqlDataAdapter(command);
                        da.Fill(dt);
                    }
                }
                var sNumRows = dt.Rows.Count.ToString();
                var sDT = JsonConvert.SerializeObject(dt);
                result = "{ \"current\": 1, \"rowCount\": 10, \"rows\": " + sDT + ", \"total\": " + sNumRows + " }";
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cmd.Dispose();
                THF.Models.SQLConnectionManager.CloseConn(con);
            }
            return result;
        }
