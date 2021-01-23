    public UserInformation GetUserInformation()
    {
            UserInformation UserInfo= new UserInformation();
            List<Username> lstUsername= new List<Username>();
            List<UserSetting> lstUserSetting= new List<UserSetting>();
            lstUserSetting=db.UserSettings.ToList();
            lstUsername=db.Usernames.ToList();
            UserInfo.Usernames =lstUsername;
            UserInfo.UserSettings =lstUserSetting;
            return UserInfo;
    }
 
