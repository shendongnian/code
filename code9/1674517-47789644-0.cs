    public class SqlParameterizer
    {
        private SqlProvider Provider { get; set; }
        private List<IDbDataParameter> ParameterList { get; set; }
        public SqlParameterizer(SqlProvider sqlProvider)
        {
            this.Provider = sqlProvider;
            this.ParameterList = new List<IDbDataParameter>();
        }
        public void Add(string parameterName, object parameterValue)
        {
            switch(this.Provider)
            {
                case SqlProvider.MsSql:
                    this.ParameterList.Add(new SqlParameter(parameterName, parameterValue));
                    break;
                case SqlProvider.MySql:
                    this.ParameterList.Add(new MySqlParameter(parameterName, parameterValue));
                    break;
                case SqlProvider.OracleSql:
                    throw new Exception($"SqlProvider '{this.Provider}' not supported yet...");
                default:
                    throw new Exception($"Unknown SqlProvider '{this.Provider}'");
            }
        }
        public IDbDataParameter[] GetParameters()
        {
            return ParameterList.ToArray();
        }
    }
