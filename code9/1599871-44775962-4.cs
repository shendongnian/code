    public void OnDataChange(DataSnapshot snapshot)
    {
        var children = snapshot.Child("users")?.Children?.ToEnumerable<DataSnapshot>();
        List<User> list = new List<User>();
        HashMap map;
        foreach (DataSnapshot s in children)
        {
            map = (HashMap)s.Value;
            list.Add(new User(map.Get("username")?.ToString(), map.Get("email")?.ToString()));
        }
    }
 
