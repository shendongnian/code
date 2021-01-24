    var data = 
        yourDataTable.AsEnumerable()
                     .GroupBy(row => row.Field<string>("Month"))
                     .Select(group => 
                     {
                         var temp = new Dictionary<string, object>
                         {
                             { "month", group.Key }
                         }
                         foreach(var row in group)
                         {
                             temp.Add(row.Field<string>("SARType"), row.Field<int>("Count"));
                         }
                         return temp;
                     });
    serializedData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
