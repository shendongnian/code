    public async Task UpdateData() {
        var month = (cbMonths.SelectedItem as MonthView).ID;
        var year = (cbYears.SelectedItem as YearView).ID;
        var deviceTypeID = (int)DeviceType;
        var task1 = GetCalendar(month, year, deviceTypeID);
        var task2 = GetWorkTypes(); 
        await Task.WhenAll(task1, task2);
        var calendar = task1.Result;
        var workTypes = task2.Result;
    }
