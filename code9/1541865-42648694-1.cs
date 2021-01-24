    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Internal;
    
    ...
    var model = set.GetService<IDbContextServices>().Model;
    var entityType = model.FindEntityType(typeof(T));
    var properties = entityType.GetProperties();
    var primaryKeyName = entityType.FindPrimaryKey().Properties.First().Name;
    var sortedSet = (set.OrderBy(e=> e.GetType().GetProperty(primaryKeyName).GetValue(e,null))).ToList();
    ...
