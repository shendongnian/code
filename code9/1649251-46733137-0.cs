    /// <summary>
    /// OleDb connection manager for SQL Server
    /// </summary>
    public class EzSqlOleDbCM : EzOleDbConnectionManager
    {
        public EzSqlOleDbCM(EzPackage parent) : base(parent) { }
        public EzSqlOleDbCM(EzPackage parent, ConnectionManager c) : base(parent, c) { }
        public EzSqlOleDbCM(EzPackage parent, string name) : base(parent, name) { }
        public EzSqlOleDbCM(EzProject parentProject, string streamName) : base(parentProject, streamName) { }
        public EzSqlOleDbCM(EzProject parentProject, string streamName, string name) : base(parentProject, streamName, name) { }
        public void SetConnectionString(string server, string db)
        {
            ConnectionString = string.Format("provider=sqlncli11;integrated security=sspi;database={0};server={1};OLE DB Services=-2;Auto Translate=False;Connect Timeout=300;",
                db, server);
        }
    }
