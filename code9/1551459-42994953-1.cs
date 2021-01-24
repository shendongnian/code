     var model = db.Groups
                 .Include(x => x.GroupUser)
                 .FirstOrDefault(x => x.GroupId == group.GroupId);
     db.TryUpdateManyToMany(model.GroupUser, listOfNewUsers
     .Select(x => new GroupUser
     {
         UserId = x,
         GroupId = group.GroupId
     }), x => x.UserId );
