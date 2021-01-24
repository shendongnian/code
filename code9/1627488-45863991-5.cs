    var result = Hotels.Where(hotel => hotel...)
        .Select(hotel => new
        {
            StoredProcedureValue = CallStoredprocedure(hotel,...),
            Hotel = hotel,
        })
        .AsEnumerable()  // bring the result to local memory
        .Orderby(item => item.StoredProcedureValue)
        .Select(item => item.Hotel);
