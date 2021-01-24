    public static IEnumerable<Users> ToUsers(this IEnumerable<UserVm> query)
    {
    	return query.Select(users => new Users{
            Name = users.Name,
            Age = users.Age, 
            Location = users.Location
        });
    }
