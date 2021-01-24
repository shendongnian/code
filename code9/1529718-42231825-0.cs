    public void ProceesData<T>(IList<T> param1, string date1)
    {
        Parallel.ForEach(T, (currentItem) =>
        {
              dynamic obj = currentItem; 
              int custId = obj.CustID 
        });
    }
