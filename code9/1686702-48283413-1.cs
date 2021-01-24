    List<ObjectDo> listDos = ...
    using(var bcp = new SqlBulkCopy(connection)) 
    using(var reader = ObjectReader.Create(listDos,
        "Id", "FkId", "Status", "RecordFrom")) 
    { 
      bcp.DestinationTableName = "SomeTable"; 
      bcp.WriteToServer(reader); 
    }
