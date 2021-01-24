    private async Task CheckWhiteList(PowerShell power)
    {
        switch ((Building)Model.BuildingSelectedIndex)
        {
            case Building.CaneRidge:
                await InvokeScriptIfNotYetWhiteListedAsync(power, Model.UserID, (CaneRidgeSettings.Departments)Model.DepartmentSelectedIndex);
                break;
            case Building.Carothers:
                await InvokeScriptIfNotYetWhiteListedAsync(power, Model.UserID, (CarothersSettings.Departments)Model.DepartmentSelectedIndex);
                break;
            case Building.CSC:
                await InvokeScriptIfNotYetWhiteListedAsync(power, Model.UserID, (CSCSettings.Departments)Model.DepartmentSelectedIndex);
                break;
            case Building.HQ:
                await InvokeScriptIfNotYetWhiteListedAsync(power, Model.UserID, (HQSettings.Departments)Model.DepartmentSelectedIndex);
                break;
            default:
                break;
        }
    }
    private async Task InvokeScriptIfNotYetWhiteListedAsync(PowerShell power, string userID, Enum department)
    {
        var history = new KeyValuePair<string, Enum>(userID, department);
        if (!WhiteList.Contains(userID))
        {
            WhiteList.Add(history.Key, history.Value)
            await power.InvokeAsync()
        }
    }
