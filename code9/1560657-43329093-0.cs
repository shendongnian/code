    using System;
    using System.IO;
    class Test
    {
        public static void Main()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
    
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
            }
        }
    }
