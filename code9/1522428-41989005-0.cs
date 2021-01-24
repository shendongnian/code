    public enum DriveType : int
    {
    Unknown = 0,
    NoRoot = 1,
    Removable = 2,
    Localdisk = 3,
    Network = 4,
    CD = 5,
    RAMDrive = 6
    }
    
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern int GetDriveType(string lpRootPathName);
