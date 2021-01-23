    public string ConvertDataTabletoJSON(DataTable dt) 
    {
        List < Dictionary < string, object >> rows = new List < Dictionary < string, object >> ();
        Dictionary < string, object > row;
        foreach(DataRow dr in dt.Rows) 
    	{
           row = new Dictionary < string, object > ();
           foreach(DataColumn col in dt.Columns) {
              row.Add(col.ColumnName, dr[col]);
           }
           rows.Add(row);
        }
    	System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        serializer.Serialize(rows);
     }
