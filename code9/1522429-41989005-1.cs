    using System;
    using System.Runtime.InteropServices;
    
    void GetDrives()
    {
         foreach (string s in Environment.GetLogicalDrives())
         Console.WriteLine(string.Format("Drive {0} is a {1}.",
         s, Enum.GetName(typeof(DriveType), GetDriveType(s))));
    }
