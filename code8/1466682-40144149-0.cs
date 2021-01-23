    var task1 = Task1();
    var task2 = Task2();
    Console.WriteLine("1");
    await Task.WhenAll(task1, task2);
    Console.WriteLine("2");
    private async Task Task1()
    {
      await Task.Run(() =>
      {
        Console.WriteLine("11");
        Thread.Sleep(1000);
        Console.WriteLine("12");
      });
      Console.WriteLine("13");
      var innerTasks = new List<Task>();
      for (var i = 0; i < 10; i++)
      {
        innerTasks.Add(Task.Run(() =>
        {
          Console.WriteLine("1_" + i + "_1");
          Thread.Sleep(500);
          Console.WriteLine("1_" + i + "_2");
        }));
        await Task.WhenAll(innerTasks);
      }
      Thread.Sleep(1000);
      Console.WriteLine("14");
    }
    private async Task Task2()
    {
      await Task.Run(() =>
      {
        Console.WriteLine("21");
        Thread.Sleep(1000);
        Console.WriteLine("22");
      });
      Console.WriteLine("23");
      Thread.Sleep(1000);
      Console.WriteLine("24");
    }
