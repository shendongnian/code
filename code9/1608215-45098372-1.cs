    public MyToolWindow() : base(null)
            {
                this.Caption = "TestToolWindow";
                List<User> users = new List<User>();
                users.Add(new User() { Id = 1, Name = "Test Xu", Birthday = new DateTime(1971, 7, 23) });
                users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
                users.Add(new User() { Id = 3, Name = "Jack Doe", Birthday = new DateTime(1991, 9, 2) });
                this.Content = new MyControl(users);
            
        }
