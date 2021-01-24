    var query = context.Table.AsQueryable();
    switch (temp) {
        case "PropertyName1":
            query = query.Where(a => a.PropertyName1 > 5);
            break;
        case "PropertyName2":
            query = query.Where(a => a.PropertyName2 > 15);
            break;
    }
