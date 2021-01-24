    if(result != null)
            { 
            foreach (var user in result.Users)
            {
                var roles = db.Users.Where(x => x.UserId == user.Id).Select(x => x.AspNetUsers.AspNetRoles).FirstOrDefault();
                user.ListOfRoles = roles.Select(x => x.Name).ToList();
            }
            }
