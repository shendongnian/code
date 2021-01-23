    string groupIds = Request.QueryString["MultiAssignInteractionGrouIds"];
    if (!string.IsNullOrEmpty(groupIds) &&  groupIds != "-2")
    {
        TheGroupIds = groupIds.Split(new[]{ ','}, StringSplitOptions.RemoveEmptyEntries)
         .Select(int.Parse)
         .Distinct()
         .ToList(); 
    }
