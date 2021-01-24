    public Tuple<IEnumerable<T1>, IEnumerable<T2>> GetMultiple<T1, T2>(string sql, object parameters,
                                            Func<GridReader, IEnumerable<T1>> func1,
                                            Func<GridReader, IEnumerable<T2>> func2)
            {
                var objs = getMultiple(sql, parameters, func1, func2);
                return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>);
            }
    
            public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> GetMultiple<T1, T2, T3>(string sql, object parameters,
                                            Func<GridReader, IEnumerable<T1>> func1,
                                            Func<GridReader, IEnumerable<T2>> func2,
                                            Func<GridReader, IEnumerable<T3>> func3)
            {
                var objs = getMultiple(sql, parameters, func1, func2, func3);
                return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>, objs[2] as IEnumerable<T3>);
            }
    
            private List<object> getMultiple(string sql, object parameters,params Func<GridReader,object>[] readerFuncs )
            {
                var returnResults = new List<object>();
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString))
                {
                    var gridReader = db.QueryMultiple(sql, parameters);
    
                    foreach(var readerFunc in readerFuncs)
                    {
                        var obj = readerFunc(gridReader);
                        returnResults.Add(obj);
                    }
                }
    
                return returnResults;
            }
