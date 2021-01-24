    public List<V> ExecStoredProc<V>(string storedProcedureName, KeyValuePair<string, string>[] parameters)
    {
        if (parameters.Any())
        {
            SqlParameter[] sqlParams = patameters.Select(x => new SqlParameter("@" + x.Key, x.Value)).ToArray();
            var result = _context.Database
                    .SqlQuery<V>(storedProcedureName + " " + string.Join(" ", patameters.Select(x => "@" + x.Key)), sqlParams)
                    .ToList();
            _context.Database.Connection.Close();
            return result;
        }
        else
        {
            var result = _context.Database
                    .SqlQuery<V>(storedProcedureName)
                    .ToList();
            _context.Database.Connection.Close();
            return result;
        }
    }
