    public void NavigateToPageTwo()
    {
          var task = GetData();
          task.Wait(); //Wait till finish the task
          var myData = task.Result;
          Navigate(myData);
    }
    
    public async Task<MyData> GetData()
    {
         return await some method...
    }
