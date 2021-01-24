    BtnCountViews[] arr = new BtnCountViews[365]; // or 366?
    // suppose DayOfYear begins with 0.
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = new BtnCountViews { DayOfYear = i };
    }
    foreach (BtnCountViews item in btnCountViewsList)
    {
        arr[item.DayOfYear].BtnCount = item.BtnCount;
        arr[item.DayOfYear].Views = item.Views;
    }
