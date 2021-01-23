    String[] array = new String[5];
    var user = UserController.GetUserByName(UserInfo.Username);
    for (int x = 0; x < user.Roles.Count(); x++)
    {
     array[x] = user.Roles[x];
    }
