    SqlParameter param = new SqlParameter();
    
                param.SqlDbType = SqlDbType.Structured;
                param.TypeName = "dbo.Regions";
                param.Value = myDataTable;
                param.ParameterName = "@regions";
    
    return _context.Database.SqlQuery<RegionDetails>("GetStats @regions", param);
