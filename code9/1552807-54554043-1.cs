        public virtual IEnumerable<TEntity> ExecuteSP<TEntity>(string spName, object parameters = null)
        {
            using (IDbConnection _connection = DapperConnection)
            {
                _connection.Open();
                return _connection.Query<TEntity>(spName, parameters, commandTimeout:0 , commandType: CommandType.StoredProcedure);
            }
        }
