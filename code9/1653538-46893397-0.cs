	Console.Write("error processing Railcar: ");
	foreach (var item in listrailcar)
    {
        Console.Write(string.Format("{0}" + " is " + "{1}. ", item.Item1, item.Item2));
    }	
    Console.WriteLine();
