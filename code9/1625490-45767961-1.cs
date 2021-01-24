     public IEnumerable<LoginDTO> GetLoginCrediential()
     {
                     var x = (from n in db.LoginCrediential orderby n.Id
                        select new LoginDTO
                        {
                            Id=n.Id,
                            UserName=n.UserName,
                            Password=n.Password,
                            Role=n.Role
                        }).ToList();
                return x;
    }
