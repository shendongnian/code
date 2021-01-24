    public static TReturn GetSettings<TInput,TReturn>(string siteId, Expression<Func<TInput, TReturn>> properties,string query)
        {
            var _data = DbTool.SqlExec<TReturn>(PowerDetailContext.GetConnectionString(siteId), CommandType.Text, query);
    
            return _data != null ? _data.FirstOrDefault() : default(TReturn);
        }
