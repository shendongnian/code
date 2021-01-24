    public string DataTableToJSONWithJavaScriptSerializer(DataTable table) 
    {  
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();  
        List < Dictionary < string, object >> parentRow = new List < Dictionary < string, object >> ();  
        Dictionary < string, object > childRow;  
        foreach(DataRow row in table.Rows) 
        {  
            childRow = new Dictionary < string, object > ();  
            foreach(DataColumn col in table.Columns) 
            {  
                childRow.Add(col.ColumnName, row[col]);  
            }  
            parentRow.Add(childRow);  
        }  
        return jsSerializer.Serialize(parentRow);  
    }  
