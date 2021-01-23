    Stopwatch watch = new Stopwatch();
    string str1 = "MyTest";
    string str2 = str1.Substring(0,2)+"Test";
    watch.Start();
    if(str1 == str2)
    {
        Console.WriteLine("str1 == str2");
    }
    watch.Stop();
    Console.WriteLine(watch.Elapsed);
    watch.Restart();
    var obj1 = (object)str1;
    var obj2 = (object)str2;
    if(obj1 == obj2)
    {
        Console.WriteLine("obj1 == obj2");
    }
    watch.Stop();
    Console.WriteLine(watch.Elapsed);
    string str3 = "MyTest";
    string str4 = "MyTest";
    watch.Restart();
    if (str3 == str4)
    {
         Console.WriteLine("str3 == str4");
    }
    watch.Stop();
    Console.WriteLine(watch.Elapsed);
    watch.Restart();
    watch.Restart();
    var obj3 = (object)str3;
    var obj4 = (object)str4;
    if (obj1 == obj2)
    {
        Console.WriteLine("obj3 == obj4");
    }
    watch.Stop();
    Console.WriteLine(watch.Elapsed);
    if (true)
    {
         Console.WriteLine("true");
    }
    watch.Stop();
    Console.WriteLine(watch.Elapsed);
