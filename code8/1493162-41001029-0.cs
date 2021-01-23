    async Task MyMethod()
    {
       ...
    }
    public void WaitOnTask()
    {
      var resultTask = MyMethod();
      resultTask.GetAwaiter().GetResult();
    }
