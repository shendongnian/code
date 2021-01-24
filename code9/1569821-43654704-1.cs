    var qDict = query as IDictionary<string, object>;
    Console.WriteLine(qDict["bool"]);
    Console.WriteLine(qDict[" b o o (g)? l \"e:)\""]);
    Console.WriteLine(qDict[""]);
    // Prints:
    //   True
    //   False
    //   True
