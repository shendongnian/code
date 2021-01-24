       from p in myUserList
       group p by p.UserId into gcs
       select new FinalUsers()
       {
           UserId = gcs.Key,
           UserFirstName = gcs.Select(g => g.UserFirstName).First() ,
           UserLastName = gcs.Select(g => g.UserLastName ).First(),
           UserEmail = gcs.Select(g => g.UserEmail).First() ,
           RoleId = gcs.Select(g => g.RoleId).ToList(),
           RoleName = gcs.Select(g => g.RoleName).ToList(),
           GroupId= gcs.Select(g => g.GroupId).ToList(),
           GroupName= gcs.Select(g => g.GroupName).ToList()
       }
