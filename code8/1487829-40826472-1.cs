     var _Users = (from s in db.Users
                     from ur in s.Roles
                     join r in db.Roles on ur.RoleId equals r.Id
                     select new MyViewModel 
                     {
                        firstproperty = s.Id,//initialize every property like this
                         s.Email,
                         s.FirstName,
                         s.LastName,
                         Name = s.UserName,
                         Role = r.Name,
                     }).ToList();//call to List
    class MyViewModel 
    {
      //define properties you needto show in view
    }
