    var query = dt.AsEnumerable()
        .Where(r=> r.Field<DateTime>("Date") >=‌ ​dateTimeStart.Value 
                && r.Field<DateTime>("Date") <= dateTimeEnd.Value); 
    if(query.Any())
        dtFiltered = query.CopyToDataTable(); 
