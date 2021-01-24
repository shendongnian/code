    var monthNo1 = new List<int>();
    if(!string.IsNullOrEmpty(Legacy.Month1[i]))
    {
    if (Legacy.Month1[i].Trim() == "January")
    monthNo1 .Add(1);
    if (Legacy.Month1[i].Trim() == "February")
    monthNo1 .Add(2);
    ...
    }
    
    for (int j = 0; i < monthNo1.Length - 1; j++)
    {
        Console.WriteLine(monthNo1[j]);    
    }
