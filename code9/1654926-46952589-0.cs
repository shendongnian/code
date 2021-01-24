    foreach (var group in rowDomainGroups)
    {
        bool isValid = !group.Skip(1).Any();
        if (isValid)
            recordList.Add(new Record
            {
                Row = group.Key.Row,
                Domain = group.Key.Domain,
                Details = group.First().Field<string>("Details"),
                Username = group.First().Field<string>("Username"),
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
