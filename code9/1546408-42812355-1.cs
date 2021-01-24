    items = items.Select(item => {
        item.area = Regex.Replace(item.area, @"\s+", ""); // remove all white spaces
        item.address = Regex.Replace(item.address, @"\s+", ""); // remove all white spaces
        return item; // return processed item...
    }).ToList(); // return as a List
