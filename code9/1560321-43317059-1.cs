        IEnumerable<UserMenuBar> userMenuBar = from users in Users join
                                                menus in Menus on users.Id
                                                 equals menus.UserId
                                                  select
                                                   {
                                                     MenuId = menus.Id,
                                                     MenuTitle = menus.Title
                                                   };
