        Stopwatch stopwatch;
        Console.WriteLine("{0} Number of items in list", n);
        List<ClassA> listOfClassA2 = new List<ClassA>();
        List<ClassB> listOfClassB2 = new List<ClassB>();
        for (int i = 0; i < 10000000; i++)
        {
            listOfClassA2.Add(new ClassA(DateTime.Now, 1, 2, 3));
        }
        stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
        listOfClassB2 = listOfClassA2.ConvertAll((ClassA a) => new ClassB(a));
        stopwatch.Stop();
        Console.WriteLine("ConvertAll " + stopwatch.ElapsedMilliseconds + "ms");
        List<ClassA> listOfClassA = new List<ClassA>();
        List<ClassB> listOfClassB = new List<ClassB>();
        for (int i = 0; i < 10000000; i++)
        {
            listOfClassA.Add(new ClassA(DateTime.Now, 1, 2, 3));
        }
        // Select time
        stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
        listOfClassB = listOfClassA.Select(x => new ClassB(x)).ToList();
        stopwatch.Stop();
        Console.WriteLine("Select " + stopwatch.ElapsedMilliseconds + "ms");
