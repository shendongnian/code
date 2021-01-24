     public IEnumerable<T> ExcecuteSelectCommand<T>(string command, string connectionString)
        {
            var relevantConnectionString = GetConnectionStringWithoutDriver(connectionString);
            using (var conn = new NpgsqlConnection(relevantConnectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = command;
                        var reader = cmd.ExecuteReader();
                        return CreateList<T>(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("There was exception while excecuting the Select Command for Detail, here is exception detail. " + ex.Message, ex);
                }
            }
        }
        private string GetConnectionStringWithoutDriver(string connection)
        {
            return connection.Replace("Driver={Amazon Redshift (x64)}; ", string.Empty);
        }
        private List<T> CreateList<T>(NpgsqlDataReader reader)
        {
            var results = new List<T>();
            Func<NpgsqlDataReader, T> readRow = this.GetReader<T>(reader);
            while (reader.Read())
            {
                try
                {
                    var readData = readRow(reader);
                    results.Add(readData);
                }
                catch
                {
                    throw new Exception("Data mismatch exception has occured");
                    //Log the information when data failed to load
                }
            }
            return results;
        }
        private Func<NpgsqlDataReader, T> GetReader<T>(NpgsqlDataReader reader)
        {
            Delegate resDelegate;
            List<string> readerColumns = new List<string>();
            for (int index = 0; index < reader.FieldCount; index++)
            {
                readerColumns.Add(reader.GetName(index));
            }
            // determine the information about the reader
            var readerParam = Expression.Parameter(typeof(NpgsqlDataReader), "reader");
            var readerGetValue = typeof(NpgsqlDataReader).GetMethod("GetValue");
            // create a Constant expression of DBNull.Value to compare values to in reader
            var dbNullValue = typeof(System.DBNull).GetField("Value");
            //var dbNullExp = Expression.Field(Expression.Parameter(typeof(System.DBNull), "System.DBNull"), dbNullValue);
            var dbNullExp = Expression.Field(expression: null, type: typeof(DBNull), fieldName: "Value");
            // loop through the properties and create MemberBinding expressions for each property
            List<MemberBinding> memberBindings = new List<MemberBinding>();
            foreach (var prop in typeof(T).GetProperties())
            {
                // determine the default value of the property
                object defaultValue = null;
                if (prop.PropertyType.IsValueType)
                    defaultValue = Activator.CreateInstance(prop.PropertyType);
                else if (prop.PropertyType.Name.ToLower().Equals("string"))
                    defaultValue = string.Empty;
                if (readerColumns.Contains(prop.Name.ToLower()))
                {
                    // build the Call expression to retrieve the data value from the reader
                    var indexExpression = Expression.Constant(reader.GetOrdinal(prop.Name.ToLower()));
                    var getValueExp = Expression.Call(readerParam, readerGetValue, new Expression[] { indexExpression });
                    // create the conditional expression to make sure the reader value != DBNull.Value
                    var testExp = Expression.NotEqual(dbNullExp, getValueExp);
                    var ifTrue = Expression.Convert(getValueExp, prop.PropertyType);
                    var ifFalse = Expression.Convert(Expression.Constant(defaultValue), prop.PropertyType);
                    // create the actual Bind expression to bind the value from the reader to the property value
                    MemberInfo mi = typeof(T).GetMember(prop.Name)[0];
                    MemberBinding mb = Expression.Bind(mi, Expression.Condition(testExp, ifTrue, ifFalse));
                    memberBindings.Add(mb);
                }
            }
            // create a MemberInit expression for the item with the member bindings
            var newItem = Expression.New(typeof(T));
            var memberInit = Expression.MemberInit(newItem, memberBindings);
            var lambda = Expression.Lambda<Func<NpgsqlDataReader, T>>(memberInit, new ParameterExpression[] { readerParam });
            resDelegate = lambda.Compile();
            return (Func<NpgsqlDataReader, T>)resDelegate;
        }
