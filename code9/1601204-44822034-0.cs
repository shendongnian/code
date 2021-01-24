       foreach (var item in users)
        {
            // this is broken and doesnt add any functionality should simply go away,
            // item.UserName shouldn't have anything to do with role of the user,
            // you are creating this list for every single iteration trough the userlist
            SelectList list = new SelectList(Roles.GetUsersInRole(item.UserName));
            // here you are adding the user to your list only if its empty, by your result it seems like it's always empty
            // that means that the previous statement in your code doesn't really
            // filter anything
            if (list.Count() == 0)
            {
                usersNoRoles.Add(item);
            }
        }
