    class PublicVariable
    {
        public static string ActiveUser() => UserInfo.Username;
        public static string ActiveUserPath() => $@"{Application.StartupPath}\{ActiveUser()}";
        public static string ActiveUserImg() => $@"{ActiveUserPath()}\User.png";
    }
    class UserInfo
    {
        public static string Username = "-1064548"; //Working 
    }
    class Starting
    {
        public void Login (string Username, string Pwd)
        {
            UserInfo.Username = "BruceWayne";
            MessageBox.Show (PublicVariable.ActiveUser().ToString ());
        }
    }
