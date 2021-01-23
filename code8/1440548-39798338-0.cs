        private readonly ApplicationDbContext _applicationDbContext;
        public DatabaseServices(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public List<T> ExecuteStoreProcedure<T>(string storedProcedure, List<SqlParameter> parameters) where T : new()
        {
            using (var cmd = _applicationDbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = storedProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                // set some parameters of the stored procedure
                foreach (var parameter in parameters)
                {
                    parameter.Value = parameter.Value ?? DBNull.Value;
                    cmd.Parameters.Add(parameter);
                }
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                using (var dataReader = cmd.ExecuteReader())
                {
                    var test = DataReaderMapToList<T>(dataReader);
                    return test;
                }
            }
        }
        private static List<T> DataReaderMapToList<T>(DbDataReader dr)
        {
            List<T> list = new List<T>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    var obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (!Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            return new List<T>();
        }
    }
