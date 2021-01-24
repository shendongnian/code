    using (var dapperQuery = connection.QueryMultiple(sql)) {
        while(!dapperQuery.IsConsumed) { //<-- query multiple until consumed
            var list = dapperQuery.Read<T>().ToList();
            ... /* Do something with list */
        }
    }
 
