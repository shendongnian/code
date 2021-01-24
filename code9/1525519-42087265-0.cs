    //overriding the Equals method
    public override bool Equals(object obj) 
    {
        User user = obj as User;
        if(user == null)
            return false;
        return this.FullName == user.FullName;
    }
    //using the Contains method to check if you can add
    if(!users.Contains(user)) 
    {
        users.Add(user);
    }
