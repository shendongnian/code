    foreach (DataRow r in t.Rows)
    {
        CustObject b = new CustObject();
        b.PropertyName = r.ReturnIntForField("ColumnName");         
        b.PropertyName1 = r.ReturnDateTimeFromDataRowField("ColumnName1");
    }
