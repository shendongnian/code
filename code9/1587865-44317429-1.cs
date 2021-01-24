    public async Task<Data> SetLineChartDataAsync()
    {
        paymentTask = APICalls.SetLineChartData();
        interestTask = APICalls.SetInterestDataList();
        await Task.WhenAll(new [] { paymentTask, interestTask });
        return new Data(paymentTask.Result, interestTask.Result);
    } 
