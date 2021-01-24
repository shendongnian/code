    [NotMapped]    
    public List<User> Admins
    {
      get
      {
        return this.Users.Where(user => user.IsAdmin);
      }
    }
