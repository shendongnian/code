    var stateLeadSettings = new List<StateLeadSettings>{
    	new StateLeadSettings() { StateCode = "AK" },
    	....
    };
    var codes = stateLeadSettings.Select(x => x.StateCode).ToList();
    var existed = context.StateLeadSettings.Where(x => codes.Contains(x.StateCode))
    				.Select(x => x.StateCode).ToList();
    context.StateLeadSettings.AddRange(stateLeadSettings
    				.Where(x => !existed.Contains(x.StateCode)).ToList());
    context.SaveChanges();
