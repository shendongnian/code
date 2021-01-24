     private async Task<long> CalculateSomething(string numberOne, MyStatus status)
     {
        var result = await this.dataBase.Something.CountAsync(item => 
        item.NumberOne== numberOne && item.Status == (short)status);
        var resultWithDate = await this.dataBase.Something.CountAsync(item =>  item.NumberOne== numberOne && item.Status == (short)status).ToList();
        resultWithDate.Where(!this.IsOlderThan30Days(item.Date))
        return result;
     }
