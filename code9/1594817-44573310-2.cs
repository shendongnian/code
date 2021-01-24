    public IQueryable<Category> Query(int userId)
    {
        var db = new Context();
        var groupUsers = db.GroupUsers.Where(x => x.UserId == userId).Select(gu => gu.GroupId);
        var first = db.Privileges
            .Join(db.PrivilegeTypes, p => p.PrivilegeTypeId, pt => pt.PrivilegeTypeId, (p, pt) => new { P = p, PT = pt })
            .Where(join => join.P.PrivilegeValue > 0 &&
                            join.PT.Code == "code" &&
                            join.P.ObjectTypeId == "SELECT" &&
                            join.P.ObjectTypeId == "1");
        var second = first.Where(join => join.P.UserId == userId || groupUsers.Contains(join.P.UserId));
        return db.Categories.Where(c => first.All(join => join.P.ObjectId != c.CategoryId) ||
                                        second.Any(join => join.P.ObjectId == c.CategoryId));
    }
    Query(57); // Look up UserID 57
