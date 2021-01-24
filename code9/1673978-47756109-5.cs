    double? [] sum = new double?[result.Pages.Length];
    
    for (var i = 0; i < result.Pages.Length; i++)
    {
        sum[i] = 0;
        for (var j = 0; j < result.Pages[i].Actual.Length; j++)
        {
            sum[i] += result.Pages[i].Actual[j];
        }    
    }
