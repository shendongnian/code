    var  groupAndMembers = await _tokenService.Token.GetGraphServiceClient()
        .Groups["02bd9fd6-8f93-4758-87c3-1fb73740a315"]
        .Request()
        .Expand("members")
        .GetAsync();
    
    var usersInGroup = groupAndMembers.Members.ToList();
