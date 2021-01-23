        foreach (ManagementObject drive in search.Get())
                {
                    string antecedent = drive["DeviceID"].ToString(); // the disk we're trying to find out about
                    antecedent = antecedent.Replace(@"\", "\\"); // this is just to escape the slashes
                    string query = "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + antecedent + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition";
                    using (ManagementObjectSearcher partitionSearch = new ManagementObjectSearcher(query))
                    {
                        foreach (ManagementObject part in partitionSearch.Get())
                        {
                            //...pull out the partition information
                            MessageBox.Show(part["DeviceID"].ToString());
                            query = "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + part["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition";
                            using (ManagementObjectSearcher logicalpartitionsearch = new ManagementObjectSearcher(query))
                                foreach (ManagementObject logicalpartition in logicalpartitionsearch.Get())
                                MessageBox.Show(logicalpartition["DeviceID"].ToString());
                        }
                        
                    }
                }
        
