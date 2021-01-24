     You need to do this in two steps if you don't want to include another property to your User object. And I think this following way is easier.
           var unSorteUsers = (from u in bd.USERS where u.ID != 12
                                where u.ID != 12
                                select new
                                {
                                    User = u,
                                    CR = 12
                                });
            
            var sortedUsers = (from u in unSorteUsers
                               orderby u.CR
                               select new User
                               {
                                   ID = u.User.ID,
                                   //All other properties.
                               });
