    case BUILDING:
        history = new KeyValuePair<string, Enum>(Model.UserID, (DEPARTMENTSETTINGS.Departments)Model.DepartmentSelectedIndex);
        if (!WhiteList.Contains(history))
        {
            WhiteList.Add(history.Key, history.Value);
            await power.InvokeAsync();
        }
        break;
