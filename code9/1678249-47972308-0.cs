    var list = new List<double>();
    list.Add(1.1);
    list.Add(2.2);
    list.Add(3.4);
    list.Add(4.8);
    list.Add(5.0);
    
    var array = list.ToArray();
    
    //here you can see that array has a length of 5
    System.Diagnostics.Debug.WriteLine($"My array contains {array.Length}.");
