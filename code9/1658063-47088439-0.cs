	public static Dictionary<Building, Func<int, Enum>> mySwitch = new Dictionary<Building, Func<int, Enum>>()
	{
		{ Building.CaneRidge, n => (CaneRidgeSettings.Departments)n },
		{ Building.Carothers, n => (CarothersSettings.Departments)n },
		{ Building.CSC, n => (CSCSettings.Departments)n },
		{ Building.HQ, n => (HQSettings.Departments)n },
	};
	
	private async Task CheckWhiteList(PowerShell power)
	{
		var history = new KeyValuePair<string, Enum>(Model.UserID, mySwitch[(Building)Model.BuildingSelectedIndex](Model.DepartmentSelectedIndex));
		if (!WhiteList.Contains(history))
		{
			WhiteList.Add(history.Key, history.Value);
			await power.InvokeAsync();
		}
	}
