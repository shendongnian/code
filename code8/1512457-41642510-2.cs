    {
        Object paramValue = DBNull.Value;
        DateTime value;
        if( DateTime.TryParse( txtInvoiceDate.Text, out value ) ) {
            paramValue = value;
        }
        query.Parameters.AddWithValue("@InvoiceDate", SqlDbType.SmallDateTime).Value = paramValue;
    }
    
