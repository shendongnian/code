    public static User GetUser()
    {
        var user = new User
        {
            Validator = i =>
            {
                var u = i as User;
                if (string.IsNullOrEmpty(u.FirstName))
                {
                    u.Properties[nameof(u.FirstName)].Errors.Add("First name is required");
                }
                if (string.IsNullOrEmpty(u.LastName))
                {
                    u.Properties[nameof(u.LastName)].Errors.Add("Last name is required");
                }
                if (string.IsNullOrEmpty(u.ID))
                {
                    u.Properties[nameof(u.ID)].Errors.Add("Integers is required");
                }
                else
                {
                    int x;
                    bool success = int.TryParse(u.ID.ToString(), out x);
                    if (!success)
                    {
                        u.Properties[nameof(u.ID)].Errors.Add("Integers only allowed");
                    }
                }
            }
        };
        return user;
    }
