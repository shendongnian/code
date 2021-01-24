    Console.WriteLine("\tSummary of Membership Fee");
    Console.WriteLine(new String('=', 45));
    Console.WriteLine("{0,-20} {1,-5} {2,-10} {3,-10}", "Name", "Weeks", "Discount", "Charges");
    Console.WriteLine(new String('-', 45));
    
    for (int count = 0; count < nameList.Count; count++)
    {
        Console.WriteLine("{0,-20}{1,5}{2,10}{3,10}", nameList[count], weekList[count], discountList[count], chargeList[count]);
        Console.WriteLine(new String('-', 45));
    }
