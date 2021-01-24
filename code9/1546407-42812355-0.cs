    items = items.Select(item => {
        item.area = item.area.Replace(" ", string.Empty); // remove all spaces
        item.address = item.address.Replace(" ", string.Empty); // remove all spaces
        return item; // return processed item...
    }).ToList(); // return as a List
