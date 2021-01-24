    private void TGenerateDriveDetailsFromReader<T>(SqlDataReader returnData, ref List<Systems> systemList)
        {
            try
            {
                while (returnData.Read())
                {
                    int MachineID = 0;
                    MachineID = returnData["MachineID"] is DBNull ? 0 : (int)returnData["MachineID"];
                    if (systemList.Any(x => x.ID == MachineID))
                    {
                        double totalSize = returnData["Size"] is DBNull ? 0 : Convert.ToDouble(returnData["Size"]);
                        double freeSpace = returnData["FreeSpace"] is DBNull ? 0 : Convert.ToDouble(returnData["FreeSpace"]);
                        int driveType = returnData["DriveTypeID"] is DBNull ? 0 : (int)(returnData["DriveTypeID"]);
    	    Systems systems = systemList.Where(x => x.ID == machineID).FirstOrDefault();
                        InsertDriveDetailsToList(totalSize, MachineID, freeSpace, driveType, systems);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    
    
    
        private void InsertDriveDetailsToList(double totalSize, int machineID, double freeSpace, int driveTypeID, Systems systems)
        {
            switch (driveTypeID)
            {
                case 1: systems.DriveCTotal = totalSize;
                    systems.DriveCFree = freeSpace;
                    break;
    
                case 2: systems.DriveDTotal = totalSize;
                    systems.DriveDFree = freeSpace;
                    break;
    
                case 3: systems.DriveETotal = totalSize;
                    systems.DriveEFree = freeSpace;
                    break;
    
                case 4: systems.DriveFTotal = totalSize;
                    systems.DriveCFree = freeSpace;
                    break;
    
                case 5: systems.DriveGTotal = totalSize;
                    systems.DriveGFree = freeSpace;
                    break;
    
                case 6: systems.DriveHTotal = totalSize;
                    systems.DriveHFree = freeSpace;
                    break;
            }
        } 
