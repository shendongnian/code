    MyTotalList listOfObjects = new MyTotalList();
    listOfObjects.Add(new MyObject(1,3));
    listOfObjects.Add(new MyObject(2,6));
    listOfObjects.Add(new MyObject(3,9));
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Initial list with total");
    Console.WriteLine("items in list:");
    foreach (MyObject mo in listOfObjects.Items)
      Console.Write(mo.ToString() + " ");
    Console.WriteLine();
    Console.WriteLine("Total from list of " + listOfObjects.Items.Count +" items is: " + listOfObjects.Total);
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Add three more items");
    listOfObjects.Add(new MyObject(4, 10));
    listOfObjects.Add(new MyObject(5, 11));
    listOfObjects.Add(new MyObject(6, 12));
    Console.WriteLine("items in list:");
    foreach (MyObject mo in listOfObjects.Items)
      Console.Write(mo.ToString() + " ");
    Console.WriteLine();
    Console.WriteLine("Total from list of " + listOfObjects.Items.Count + " items is: " + listOfObjects.Total);
