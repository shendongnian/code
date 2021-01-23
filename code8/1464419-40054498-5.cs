    using System.Runtime.InteropServices;
    ...
    [DllImport("userenv.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int CreateProfile(
        [In] string pszUserSid,
        [In] string pszUserName,
        System.Text.StringBuilder pszProfilePath,
        int cchProfilePath);
    ....
    var pathBuf = new System.Text.StringBuilder(240);
    var Up =  System.DirectoryServices.AccountManagement.UserPrincipal.Current;
    int Res = CreateProfile(Up.Sid.ToString(), Up.SamAccountName, pathBuf, pathBuf.Capacity);
