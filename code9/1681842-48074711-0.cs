    using Microsoft.EntityFrameworkCore;
    ...
    var modelData = db.Model.GetEntityTypes()
        .Select(t => new
        {
            t.ClrType.Name,
            NavigationProperties = t.GetNavigations().Select(x => x.PropertyInfo)
        });
