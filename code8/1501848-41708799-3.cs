    DataTable dt=new DataTable();
    dt.Colums.Add("Count");
    dt.Colums.Add("Name");
    foreach (PSObject psObject in results)
    {
       foreach(PSPropertyInfo prop in psObject.Properties)
       {
         var count=prop.Name; 
         var name=prop.Value;
         //In other words generate output as you desire.
         dt.Rows.Add(count,name);
       }
    }
