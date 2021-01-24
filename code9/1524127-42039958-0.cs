          List<DriveInfo> list = new List<DriveInfo>(DriveInfo.GetDrives());
          var condSatisfied = false;
          foreach (DriveInfo drive in list)
          {
              if (drive.DriveType == DriveType.Removable)
              {
                  if ((File.Exists(drive.RootDirectory + "Key.txt")) && 
                     File.Exists(drive.RootDirectory + "SerialNumber.txt"))
                   {
                       string KeyFromUsb = (System.IO.File.ReadAllText(drive.RootDirectory + "Key.txt"));
                       string serialusb = (System.IO.File.ReadAllText(drive.RootDirectory + "SerialNumber.txt"));
                     int serialNumbeFromUsb = Convert.ToInt32(serialusb);
                       string KeyFromDataBase = FoundKey(serialNumbeFromUsb);
                       if (KeyFromDataBase == KeyFromUsb)
                      {
                          ok = true;
                         condSatisfied = true;
                       }
                   }
               }
            }
           return condSatisfied
