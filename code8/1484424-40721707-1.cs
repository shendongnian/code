    var dataStore = new List<Policies>
    {
        new Policies
        {
            PolicyID = 1,
            PolicyName = "policy1",
            PolicyDesc = "policy1desc"
        },
        new Policies
        {
            PolicyID = 2,
            PolicyName = "policy2",
            PolicyDesc = "policy2desc"
        },
    };
    
    var policyData = dataStore.AsQueryable();
