    public IEnumerable<MyViewModel> GetData()
    {
        //var test = new List<MyData>();
        //test.Add(new MyData { Schedule_Date = new DateTime(2017, 6, 3), Start_Time = new DateTime(2017, 6, 3, 9, 0, 0), End_Time = new DateTime(2017, 6, 3, 10, 0, 0), Job_Title = "Waiter", Employee_Name = "John" });
        //test.Add(new MyData { Schedule_Date = new DateTime(2017, 6, 3), Start_Time = new DateTime(2017, 6, 3, 11, 0, 0), End_Time = new DateTime(2017, 6, 3, 12, 0, 0), Job_Title = "Driver", Employee_Name = "Own" });
        //test.Add(new MyData { Schedule_Date = new DateTime(2017, 6, 3), Start_Time = new DateTime(2017, 6, 3, 14, 0, 0), End_Time = new DateTime(2017, 6, 3, 15, 0, 0), Job_Title = "Busser", Employee_Name = "John" });
        //test.Add(new MyData { Schedule_Date = new DateTime(2017, 6, 3), Start_Time = new DateTime(2017, 6, 3, 12, 0, 0), End_Time = new DateTime(2017, 6, 3, 13, 0, 0), Job_Title = "Waiter", Employee_Name = "Damien" });
        //test.Add(new MyData { Schedule_Date = new DateTime(2017, 6, 3), Start_Time = new DateTime(2017, 6, 3, 12, 15, 0), End_Time = new DateTime(2017, 6, 3, 15, 15, 0), Job_Title = "Waiter", Employee_Name = "Damien" });
        var MyDal = new DAL();
        var test = MyDal.GetMyClassRange(DateTime.Now, DateTime.Now.AddYears(1));
        var result = test
            .GroupBy(x => new {x.Schedule_Date, x.Job_Title})
            .GroupBy(x => x.Key.Schedule_Date)
            .Select(x => new MyViewModel {Start_Date = x.Key, Jobs = x.Select(y => new MyJobsView {Job_Title = y.Key.Job_Title, Datas = y})})
            .ToList();
        return result;
    }
