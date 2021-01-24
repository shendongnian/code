     var myNonDupOfficeList = officeList
    .GroupBy(o => new { o.Address1, o.Address2, o.BusinessName })
    .OrderBy(g => g.Key.BusinessName).ThenBy(g => g.Key.Address1).ThenBy(g => g.Key.Address2)
    .Select(o => new MyBusiness
    {
        BusinessName = o.BusinessName,
        BusinessAddress1 = o.Address1,
        BusinessAddress2 = o.Address2
    }).ToList();
