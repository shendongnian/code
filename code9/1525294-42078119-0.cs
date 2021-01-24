    public int UserID;
    [NotMapped]
    public User User
    {
        get
        {
            return _context.Users.where(u=>u.UserID==UserID).FirstOrDefault();
        }
        set
        {
            UserID = value.UserID;
        }
    }
