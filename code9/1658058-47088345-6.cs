    private async Task CheckWhiteList(PowerShell power)
    {
        Enum department = GetDepartmentEnumForBuilding((Building)Model.BuildingSelectedIndex);
        await InvokeScriptIfNotYetWhiteListedAsync(power, Model.UserID, department);
    }
    private Enum GetDepartmentEnumForBuilding(Building building)
    {
        switch (building)
        {
            case Building.CaneRidge:
                return (CaneRidgeSettings.Departments)Model.DepartmentSelectedIndex;
            case Building.Carothers:
                return (CarothersSettings.Departments)Model.DepartmentSelectedIndex;
            case Building.CSC:
                return (CSCSettings.Departments)Model.DepartmentSelectedIndex;
            case Building.HQ:
                return (HQSettings.Departments)Model.DepartmentSelectedIndex;
            default:
                throw new ArgumentOutOfRangeException(nameof(building));
        }
    }
    private async Task InvokeScriptIfNotYetWhiteListedAsync(PowerShell power, string userID, Enum department)
    {
        if (!WhiteList.ContainsKey(userID))
        {
            WhiteList.Add(userID, department)
            await power.InvokeAsync()
        }
    }
