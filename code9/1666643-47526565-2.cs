      static void Main(string[] args)
      {
         Console.WriteLine("OracleGlobalization.TimeZone = {0}", Oracle.DataAccess.Client.OracleGlobalization.GetClientInfo().TimeZone);
         Console.WriteLine(String.Empty);
         Console.WriteLine("TimeZone.CurrentTimeZone.StandardName = {0}", TimeZone.CurrentTimeZone.StandardName);
         Console.WriteLine("TimeZone.CurrentTimeZone.DaylightName = {0}", TimeZone.CurrentTimeZone.DaylightName);
         Console.WriteLine(String.Empty);
         Console.WriteLine("TimeZoneInfo.Local.DisplayName = {0}", TimeZoneInfo.Local.DisplayName);
         Console.WriteLine("TimeZoneInfo.Local.Id = {0}", TimeZoneInfo.Local.Id);
         Console.WriteLine("TimeZoneInfo.Local.StandardName = {0}", TimeZoneInfo.Local.StandardName);
         Console.WriteLine("TimeZoneInfo.Local.DaylightName = {0}", TimeZoneInfo.Local.DaylightName);
         Console.WriteLine(String.Empty);
         var str = new Oracle.DataAccess.Client.OracleConnectionStringBuilder();
         str.UserID = "<username>";
         str.Password = "<password>";
         str.DataSource = "<database name>";
         using ( var con = new Oracle.DataAccess.Client.OracleConnection(str.ConnectionString) ) {
            con.Open();
            Console.WriteLine("Oracle.DataAccess: OracleConnection -> SessionInfo.TimeZone = {0}", con.GetSessionInfo().TimeZone);
            Console.WriteLine("Oracle.DataAccess: Version = {0}", FileVersionInfo.GetVersionInfo(con.GetType().Assembly.Location).FileVersion.ToString());
            var tz = new Oracle.DataAccess.Client.OracleCommand("SELECT SESSIONTIMEZONE FROM dual", con).ExecuteScalar();
            Console.WriteLine("Oracle.DataAccess: SESSIONTIMEZONE = {0}", tz.ToString());
            con.Close();
         }
         Console.WriteLine(String.Empty);
         var strm = new Oracle.ManagedDataAccess.Client.OracleConnectionStringBuilder();
         str.UserID = "<username>";
         str.Password = "<password>";
         str.DataSource = "<database name>";
         using ( var con = new Oracle.ManagedDataAccess.Client.OracleConnection(str.ConnectionString) ) {
            con.Open();
            Console.WriteLine("Oracle.ManagedDataAccess: OracleConnection -> SessionInfo.TimeZone = {0}", con.GetSessionInfo().TimeZone);
            Console.WriteLine("Oracle.ManagedDataAccess: Version = {0}", FileVersionInfo.GetVersionInfo(con.GetType().Assembly.Location).FileVersion.ToString());
            var tz = new Oracle.ManagedDataAccess.Client.OracleCommand("SELECT SESSIONTIMEZONE FROM dual", con).ExecuteScalar();
            Console.WriteLine("Oracle.ManagedDataAccess: SESSIONTIMEZONE = {0}", tz.ToString());
            con.Close();
         }
      }
