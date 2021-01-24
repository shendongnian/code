    var temp = padView.Points;
    var tempArray = padView.Points.ToArray();
    
    var databaseItem = new DatabaseItem
    {
        Name = Name.Text,
        Date = Date.Date.ToString(),
        PadViewPointsString = JsonConvert.SerializeObject(tempArray)
    };
