    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Internal;
    
    ...
    var model = set.GetService<IDbContextServices>().Model;
    var entityType = db.Model.FindEntityType(typeof(T));
    ...
