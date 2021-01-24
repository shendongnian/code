    var array1 = new int[1, 1];
    var array2 = new int[1, 1];
    Array.Copy(array1, array2, array1.Length);
    array2[0, 0] = 666;
    if (array1[0, 0] != array2[0, 0])
    {
        ApplicationView.GetForCurrentView().Title = "OK.";
    }
    else
    {
        ApplicationView.GetForCurrentView().Title = "Bug.";
    }
