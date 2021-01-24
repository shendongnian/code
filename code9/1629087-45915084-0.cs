    public async void main()
    {
      Task getDataTask = GetData();
      ...Starting tests.....
      //Do something that is not dependent upon GetData()
      await getDataTask;
      //Processing completed
      Console.Write("File GetData - complete");
    }
