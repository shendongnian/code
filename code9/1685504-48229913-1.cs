    List<UserModel> models = context.Users.Select(x =>
      new UserModel {
        Id = x.Id,
        Names = x.Languages.Take(1).Select(y=>y.Name)
         .Concat(x.Skills.Take(2).Select(y => y.Name)).ToList()
      }).ToList();
