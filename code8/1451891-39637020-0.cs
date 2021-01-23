    var usersQuery =
        from user in dbContext.Set<Model.User>()
        join ru in dbContext.Set<Model.ApplicationRoleUser>() on user.Id equals ru.UserId
        join role in this.dbContext.Set<Model.ApplicationRole>() on ru.ApplicationRoleId equals role.Id
        where ru.ApplicationId == application.Id
            && (roleId == null || ru.ApplicationRoleId == roleId.Value)
        select new
        {
            Actor = new Actor
            {
                AccountName = user.AccountName,
                DisplayName = (user.DisplayName ?? "") != "" ? user.DisplayName : user.CommonName,
                DomainName = user.DomainName,
                Email = user.Email ?? "",
                CompanyCode = user.CompanyCode,
                AdGuid = user.AdGuid,
                CommonName = user.CommonName
            },
            Type = Model.ActorType.User,
            Role = role,
        };
