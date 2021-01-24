    var visibleCheck = (VisibleTo)intFromDb;
    foreach (var visibleItem in new[] { VisibleTo.Customers, VisibleTo.Employees, VisibleTo.Managers })
    {
        if(visibleCheck.HasFlag(visibleItem) 
        {
            Console.WriteLine($"{GetEnumDescription(visibleItem)}: CHECKED");
        }
    }
