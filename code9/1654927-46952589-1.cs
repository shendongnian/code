    foreach (var group in usernameDomainGroups)
    {
        bool isValid = !group.Skip(1).Any();
        if (isValid)
            recordList.Add(new Record
            {
                Row = group.First().RowNumber,
                Domain = group.Key.Domain,
                Username = group.Key.UserName,
                Details = group.First().Row.Field<string>("Details"),
                IsValid = true,
                ErrorMessage = null
            });
        else
        {
            // tricky part, if you need further help ask
            // start with group.Select(r => new Record ....
            // then you can use recordList.AddRange(...)
        }
    }
