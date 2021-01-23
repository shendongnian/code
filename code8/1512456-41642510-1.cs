    static SqlParameter AddDateParameter(SqlCommand cmd, String parameterName, String inputValue) {
        SqlParameter p = cmd.CreateParameter();
        p.Name = parameterName;
        p.SqlDbType = SqlDbType.SmallDateTime;
        cmd.Parameters.Add( p );
        
        DateTime value;
        if( DateTime.TryParse( txtInvoiceDate.Text, out value ) ) {
            p.Value = value;
        }
        else {
            p.Value = DBNull.Value;
        }
        return p;
    }
