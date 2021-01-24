    var _companyCode = new SqlParameter("CompanyCode", "HST");
    var _sMsg = new SqlParameter("sMsg", "")
    {
        Direction = ParameterDirection.Output,
        SqlDbType = SqlDbType.VarChar
    };
    
    var sql = "exec temp_get_company @CompanyCode, @sMsg OUTPUT";
    
    var result = context.Set<Company>().FromSql(sql, _companyCode, _sMsg).ToList();
    
    var yourOutput = _sMsg.Value.ToString();
