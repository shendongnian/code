    public Expression<Func<User, bool>> GetAdults()
    {
        return user => user.Age >= 18;
    
    }
    
