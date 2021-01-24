    TempDataList<TempData> tempDataList = new TempDataList<TempData>();
    tempDataList.Add(new TempData(10, DateTime.UtcNow));
    tempDataList.Add(new TempData(20, DateTime.UtcNow));
    tempDataList.Add(new TempData(15, DateTime.MinValue));
    tempDataList.Add(new TempData(25, DateTime.MaxValue));
    Console.WriteLine(tempDataList.GetMaxTemp(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(1)).Temp);
    Console.WriteLine(tempDataList.GetMinTemp(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(1)).Temp);
