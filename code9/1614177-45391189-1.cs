    var users = myDBContext.User
                           .AsNoTracking().FromSql(...)
                           .Where(x => !x.Connections.Any(y => y.UserId == requestor.Id));
    var result = (from u1 in users
                 from u2 in u1.Connections.Select(c => c.UserConnection)
                 let commonCategories = u1.UserCategory.Select(uc1 => uc1.CategoryId)
                     .Intersect(u2.UserCategory.Select(uc2 => uc2.CategoryId))
                 orderby commonCategories.Count(), u1.ActivityDate
                 select new
                 {
                     u2.Id,
                     u2.Location,
                     u2.ActivityDate,
                     CommonCategories = commonCategories.Select(cc => cc.Id)
                 })
                 .AsEnumerable()
                 .Select(x => new
                 {
                     x.Id,
                     x.Location,
                     x.ActivityDate,
                     Categories = string.Join(",", x.CommonCategories)
                 });
