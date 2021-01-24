    private async Task CheckWhiteList(PowerShell power)
    {
        Enum department;
        switch ((Building)Model.BuildingSelectedIndex)
        {
            case Building.CaneRidge:
                department = (CaneRidgeSettings.Departments)Model.DepartmentSelectedIndex;
                break;
            case Building.Carothers:
                department = (CarothersSettings.Departments)Model.DepartmentSelectedIndex;
                break;
            case Building.CSC:
                department = (CSCSettings.Departments)Model.DepartmentSelectedIndex;
                break;
            case Building.HQ:
                department = (HQSettings.Departments)Model.DepartmentSelectedIndex;
                break;
            default:
                return;
        }
        await InvokeScriptIfNotYetWhiteListedAsync(power, Model.UserID, department);
    }
    private async Task InvokeScriptIfNotYetWhiteListedAsync(PowerShell power, string userID, Enum department)
    {
        if (!WhiteList.ContainsKey(userID))
        {
            // The Add() will throw if the userID is already in the dictionary
            // with a different department, that might need to be fixed.
            // The previous code had the same behavior.
            WhiteList.Add(userID, department)
            await power.InvokeAsync()
        }
    }
