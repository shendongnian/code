    public IEnumerable<EmployeeLocation> Search(
        int[] empNumArray, 
        string[] locationIdArray, 
        string[] extensionIdArray, 
        int[] yearArray){
        
        IEnumerable<EmployeeLocation> result = EmployeeLocationList;
        if (empNumArray != null){
            result = result.Where(r => empNumArray.Contains(r.EmpNum));
        }
        if (locationIdArray != null){
            result = result.Where(r => locationIdArray.Contains(r.LocationId));
        }
        if (extensionIdArray != null){
            result = result.Where(r => extensionIdArray.Contains(r.ExtensionId));
        }
        if (yearArray != null){
            result = result.Where(r => yearArray.Contains(r.Year));
        }
        return result;
    }
