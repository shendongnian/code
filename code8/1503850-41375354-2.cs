    public void StartLogging()
    {
        // Check the value does not already exist etc. and either add or modify.
        if (actionContext.Request.Properties.ContainsKey("ShouldLog")) {
            actionContext.Request.Properties["ShouldLog"] = true;
        }
        else {
            actionContext.Request.Properties.Add("ShouldLog", true);
        }
    }
