    public static void Main(String[] args)
    {
        int roleID = 6;
        
        UserDataAccess dataAccess = new UserDataAccess();
        IEnumerable<User> usersInRole = dataAccess.GetUsersByRoleID(roleID);
        DisplayManager displayManager = new DisplayManager(usersInRole);
        displayManager.DisplayInfo();
    }
