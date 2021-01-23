    using System.Runtime.InteropServices;
    ...
    [DllImport("userenv.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int CreateProfile(
        [In] string pszUserSid,
        [In] string pszUserName,
        System.Text.StringBuilder pszProfilePath,
        int cchProfilePath);
    ....
    public static string getUserProfilePath()
    {
		string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		if(string.IsNullOrWhiteSpace(userProfilePath) || !Directory.Exists(userProfilePath))
		{	//This will only work if we have admin...
			var pathBuf = new System.Text.StringBuilder(240);
			var Up = System.DirectoryServices.AccountManagement.UserPrincipal.Current;
			if( 0 == CreateProfile(Up.Sid.ToString(), Up.SamAccountName, pathBuf, pathBuf.Capacity) }
            {
			    userProfilePath = pathBuf.ToString();
            }
		}
        return userProfilePath;
    }
