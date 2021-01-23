    public IEnumerable<EmployeeLocation> Search(
        int[] empNumArray, 
        string[] locationIdArray, 
        string[] extensionIdArray, 
        int[] yearArray){
        
        IEnumerable<EmployeeLocation> result = EmployeeLocationList;
        if (empNumArray != null){
            foreach(var empNum in empNumArray){
                result = result.Where(r => r.EmpNum == empNum);
            }
        }
        if (locationIdArray != null){
            foreach(var locationId in locationIdArray){
                result = result.Where(r => r.LocationId);
            }
        }
        if (extensionIdArray != null){
            foreach(var extensionId in extensionIdArray){
                result = result.Where(r => r.ExtensionId == extensionId);
            }
        }
        if (yearArray != null){
            foreach(var year in yearArray ){
                result = result.Where(r => r.Year == year);
            }
        }
        return result;
    }
