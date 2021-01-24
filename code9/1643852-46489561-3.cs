    var loDateList = listOfTempDate.Where(item => item.Date <= end && item.Date >= start)
        .OrderBy(item => item.Temp);
    
    TempDate loMin = loDateList.FirstOrDefault();
    TempDate loMax = loDateList.LastOrDefault();
    
    if (loMin != null && loMax !=  null)
    {
        listBoxMaxMin.Items.Add("");
        listBoxMaxMin.Items.Add("Lowest temp: " + loMin.Temp + ", on " + loMin.Date);
        listBoxMaxMin.Items.Add("Highest temp: " + loMax.Temp + ", on " + loMax.Date);
    }
