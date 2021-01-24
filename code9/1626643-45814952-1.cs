    using (var gridReader = connection.QueryMultiple(sql)) {
        while(!gridReader.IsConsumed) { //<-- query multiple until consumed
            var list = gridReader.Read<T>().ToList();
            ... /* Do something with list */
        }
    }
 
