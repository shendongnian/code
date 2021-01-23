    DateTime dt;
    string myDate = "2016-12-10";
    bool success = DateTime.TryParse(myDate, out dt);
    Console.WriteLine(success);
    
    Console.WriteLine(DateTime.TryParse("2016-12-10", out dt));    //true
    Console.WriteLine(DateTime.TryParse("10-12-2016", out dt));    //true
    Console.WriteLine(DateTime.TryParse("2016 July, 01", out dt));    //true
    Console.WriteLine(DateTime.TryParse("July 2016 99", out dt));    //true
