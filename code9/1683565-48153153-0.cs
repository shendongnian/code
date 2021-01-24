    public static string CurrentDiskUsage()
        {
            String driveInformation ="";   //your code overwrote this with each loop
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                try
                {
    
                    if (drive.IsReady)
                    {
                        double result = 100 * (double) drive.TotalFreeSpace / drive.TotalSize;
                        result = Math.Round(result, 2, MidpointRounding.AwayFromZero);
                        driveInformation += drive.Name + Environment.NewLine + drive.DriveFormat + Environment.NewLine + "Drive total size: " + FormatBytes(drive.TotalSize) + Environment.NewLine + "Drive total free space: " + FormatBytes(drive.TotalFreeSpace) + Environment.NewLine + "Free space as percentage: " + result + "% "+Environment.NewLine;
                    }
                }
                catch (Exception e)
                {
                    DriveInformation+="Fail:"+Drive.Name+Environment.NewLine+e.Message;
                }
            }
    
           return driveInformation;
        }
