    if (sortColumn == "myColumn")
    {
        myOrderByFunc = i => i.myColumn;
    }
    elseif (sortColumn == "myOtherColumn")
    {
        myOrderByFunc = i => i.myOtherColumn;
    }
    
    if (direction == "asc")
    {
        v = v.OrderBy(myOrderByFunc);
    }
    elseif (direction == "desc")
    {
        v = v.OrderByDescending(myOrderByFunc);
    }
