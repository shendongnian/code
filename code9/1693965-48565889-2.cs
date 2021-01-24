    var temp = new List<TEntity>();
      using (var reader = await  cmd.ExecuteReaderAsync()) {
        while(await reader.ReadAsync()) {
            temp.add(CreateEntity(reader)) ;
         }
       }
    return temp;
    // this is tightly coupled to object. Generic methods can be made
    //  to convert reader to object
    public TEntity CreateEntity(SqlDataReader reader) => new TEntity()
        {
            Id = reader.GetInt32("id"),
            Col1 =  reader.GetString("col1"),
            Col2 =  reader.GetString("col2"),
            Col3 =  reader.GetString("col3")
        };
