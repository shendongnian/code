    using System.Management;
     //Define an initial scope for the following queries
     ManagementScope _Scope = new ManagementScope(@"\\" + Environment.MachineName + @"\root\CIMV2");
     //Select all Disk Drives
     SelectQuery _Query = new SelectQuery("SELECT * FROM Win32_DiskDrive");
     //Options => TimeOut infinite to avoid timeouts and forward only for speed
     EnumerationOptions _Options = new EnumerationOptions();
     _Options.Timeout = EnumerationOptions.InfiniteTimeout;
     _Options.Rewindable = false;
     _Options.ReturnImmediately = true;
     //New root Management Objet
     ManagementObjectSearcher _searcher = new ManagementObjectSearcher(_Scope, _Query, _Options);
     //Enumerate all Disk Drives
     foreach (ManagementObject _objDisk in _searcher.Get())
     {
        //Query the associated partitions of the current DeviceID
        string _AssocQuery = "Associators of {Win32_DiskDrive.DeviceID='" + 
                                              _objDisk.Properties["DeviceID"].Value.ToString() + "'}" +
                                              "where AssocClass=Win32_DiskDriveToDiskPartition";
        ManagementObjectSearcher _AssocPart = new ManagementObjectSearcher(_AssocQuery);
        _AssocPart.Options.Timeout = EnumerationOptions.InfiniteTimeout;
        //For each Disk Drive, query the associated partitions
        foreach (ManagementObject _objAssocPart in _AssocPart.Get())
        {
           Console.WriteLine("DeviceID: {0}  BootPartition: {1}", 
                             _objAssocPart.Properties["DeviceID"].Value.ToString(), 
                             _objAssocPart.Properties["BootPartition"].Value.ToString());
           //Query the associated logical disk of the current PartitionID
           string _LogDiskQuery = "Associators of {Win32_DiskPartition.DeviceID='" + 
                                   _objAssocPart.Properties["DeviceID"].Value.ToString() + "'} " +
                                   "where AssocClass=Win32_LogicalDiskToPartition";
           ManagementObjectSearcher _LogDisk = new ManagementObjectSearcher(_LogDiskQuery);
           _LogDisk.Options.Timeout = EnumerationOptions.InfiniteTimeout;
           //For each partition, query the Logical Drives
           foreach (var _LogDiskEnu in _LogDisk.Get())
           {
              Console.WriteLine("Volume Name: {0}  Serial Number: {1}  System Name: {2}",
                                _LogDiskEnu.Properties["VolumeName"].Value.ToString(),
                                _LogDiskEnu.Properties["VolumeSerialNumber"].Value.ToString(),
                                _LogDiskEnu.Properties["SystemName"].Value.ToString());
              Console.WriteLine("Description: {0}  DriveType: {1}  MediaType: {2}",
                                _LogDiskEnu.Properties["Description"].Value.ToString(),
                                _LogDiskEnu.Properties["DriveType"].Value.ToString(),
                                _LogDiskEnu.Properties["MediaType"].Value.ToString());
           }
        }
     }
