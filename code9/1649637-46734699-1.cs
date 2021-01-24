    var orderColums = request.Columns.Where(x => x.Sort != null);
    
    var filteredData = deviceList.Where(_item => _item.UserName.Contains(request.Search.Value));
    
    IColumn sortColumn = orderColums.FirstOrDefault();
    string newField = "";
    // Change first character to match column name
    newField += sortColumn.Field.ToUpper().First() + string.Join("", sortColumn.Field.Skip(1));
    var dataPage = new object();
    if (sortColumn != null)
    {
        if (sortColumn.Sort.Direction == DataTables.AspNet.Core.SortDirection.Ascending)
        {
            dataPage = filteredData.OrderBy(o => o.GetType().GetProperty(newField).GetValue(o))
                .Skip(request.Start)
                .Take(request.Length);
        }
        else
        {
            dataPage = filteredData.OrderByDescending(o => o.GetType().GetProperty(newField).GetValue(o))
                .Skip(request.Start)
                .Take(request.Length);
        }
    }
    else
    {
        dataPage = filteredData.Skip(request.Start).Take(request.Length);
    }
