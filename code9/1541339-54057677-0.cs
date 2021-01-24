    /// <summary>
    /// Npgsql Dynamic Param for Dapper
    /// </summary>
    public class PgParam : SqlMapper.IDynamicParameters
    {
        private static readonly Dictionary<SqlMapper.Identity, Action<IDbCommand, object>> paramReaderCache = new Dictionary<SqlMapper.Identity, Action<IDbCommand, object>>();
        private readonly Dictionary<string, ParamInfo> _parameters = new Dictionary<string, ParamInfo>();
        private List<object> templates;
        /// <summary>
        ///     construct a dynamic parameter bag
        /// </summary>
        public PgParam()
        {
        }
        /// <summary>
        ///     construct a dynamic parameter bag
        /// </summary>
        /// <param name="template">can be an anonymous type or a DynamicParameters bag</param>
        public PgParam(object template)
        {
            AddDynamicParams(template);
        }
        /// <summary>
        ///     All the names of the param in the bag, use Get to yank them out
        /// </summary>
        public IEnumerable<string> ParameterNames
        {
            get { return _parameters.Select(p => p.Key); }
        }
        void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            AddParameters(command, identity);
        }
        /// <summary>
        ///     Append a whole object full of params to the dynamic
        ///     EG: AddDynamicParams(new {A = 1, B = 2}) // will add property A and B to the dynamic
        /// </summary>
        /// <param name="param"></param>
        public void AddDynamicParams(
            dynamic param
        )
        {
            if (param is object obj)
            {
                if (!(obj is PgParam subDynamic))
                {
                    if (!(obj is IEnumerable<KeyValuePair<string, object>> dictionary))
                    {
                        templates = templates ?? new List<object>();
                        templates.Add(obj);
                    }
                    else
                    {
                        foreach (var kvp in dictionary)
                        {
                            Add(kvp.Key, kvp.Value);
                        }
                    }
                }
                else
                {
                    if (subDynamic._parameters != null)
                        foreach (var kvp in subDynamic._parameters)
                            _parameters.Add(kvp.Key, kvp.Value);
                    if (subDynamic.templates != null)
                    {
                        templates = templates ?? new List<object>();
                        foreach (var t in subDynamic.templates) templates.Add(t);
                    }
                }
            }
        }
        /// <summary>
        ///     Add a parameter to this dynamic parameter list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public void Add(string name, object value = null, NpgsqlDbType? dbType = null, ParameterDirection? direction = null,int? size = null)
        {
            _parameters[name] = new ParamInfo
            {
                Name = name, Value = value, ParameterDirection = direction ?? ParameterDirection.Input, DbType = dbType,
                Size = size
            };
        }
        
        /// <summary>
        ///     Add all the parameters needed to the command just before it executes
        /// </summary>
        /// <param name="command">The raw command prior to execution</param>
        /// <param name="identity">Information about the query</param>
        protected void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            if (templates != null)
                foreach (var template in templates)
                {
                    var newIdent = identity.ForDynamicParameters(template.GetType());
                    Action<IDbCommand, object> appender;
                    lock (paramReaderCache)
                    {
                        if (!paramReaderCache.TryGetValue(newIdent, out appender))
                        {
                            appender = SqlMapper.CreateParamInfoGenerator(newIdent, false, true);
                            paramReaderCache[newIdent] = appender;
                        }
                    }
                    appender(command, template);
                }
            foreach (var param in _parameters.Values)
            {
                
                var add = !((NpgsqlCommand) command).Parameters.Contains(param.Name);
                NpgsqlParameter p;
                if (add)
                {
                    p = ((NpgsqlCommand) command).CreateParameter();
                    p.ParameterName = param.Name;
                }
                else
                {
                    p = ((NpgsqlCommand) command).Parameters[param.Name];
                }
                var val = param.Value;
                p.Value = val ?? DBNull.Value;
                p.Direction = param.ParameterDirection;
                if (param.Size != null) p.Size = param.Size.Value;
                if (param.DbType != null) p.NpgsqlDbType = param.DbType.Value;
                if (add) command.Parameters.Add(p);
                param.AttachedParam = p;
            }
        }
        /// <summary>
        ///     Get the value of a parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns>The value, note DBNull.Value is not returned, instead the value is returned as null</returns>
        public T Get<T>(string name)
        {
            var val = _parameters[name].AttachedParam.Value;
            if (val == DBNull.Value)
            {
                if (default(T) != null)
                    throw new ApplicationException("Attempting to cast a DBNull to a non nullable type!");
                return default(T);
            }
            return (T) val;
        }
        private class ParamInfo
        {
            public string Name { get; set; }
            public object Value { get; set; }
            public ParameterDirection ParameterDirection { get; set; }
            public NpgsqlDbType? DbType { get; set; }
            public int? Size { get; set; }
            public IDbDataParameter AttachedParam { get; set; }
        }
    }
