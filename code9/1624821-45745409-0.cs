            var user = db.Users.First();
            var groups = db.Entry(user).Collection(u => u.UserGroups);
            if (!groups.IsLoaded)
            {
                groups.Load();
            }
