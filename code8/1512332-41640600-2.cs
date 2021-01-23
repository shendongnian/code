    List<string> myList = new List<string> { "Foo", "Foo", "Bar", "UniqueValue", "Bar" };
    
    var listGrouped = myList.GroupBy(  x => x,   //the element you want to group by
                                         (key,    //the element you grouped by
                                         element  //the new list of strings grouped 
                                         )=> new 
                                         {
                                             Key =  key,
                                             Count = element.Count()
                                         });
    
    foreach (var item in listGrouped)
    {
        Console.WriteLine("- - - - - - - -");
        Console.WriteLine(item.Key);
        Console.WriteLine(item.Count);
    }
    
    Console.ReadKey();
