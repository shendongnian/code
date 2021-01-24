    public void GenerateUsers()
    {
        GenerateClassA();
        GenerateClassB();
    }
    
    private static async void GenerateClassA()
    {
       while(true)
       {
          await Task.Delay(3000);
          classAList.Add(new ClassA());
          Console.WriteLine(classAList.Count);
       }
    }
    
    private static async void GenerateClassB()
    {
       while (true)
       {
          await Task.Delay(6000);
          classBList.Add(new ClassB());
          Console.WriteLine(classBList.Count)
       }
    }
