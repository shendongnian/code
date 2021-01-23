    class User
            {
                public string Name { get; set; }
            }
    EntityCollection<User> users = new EntityCollection<User>();
            users.Add(new User() { Name = "test1" });
            List<string> UsersList = new List<string>();
            UsersList.Add("test1");
            UsersList.Add("test2");
            UsersList.Add("test3");
            foreach (string item in UsersList)
            {
                string ls = item;
                var user = users.Where(x => x.Name == ls).FirstOrDefault();
                if(user!=null)
                    users.Remove(user); 
            }
