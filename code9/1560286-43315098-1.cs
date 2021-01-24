    var LinesInFile = System.IO.File.ReadAllLines("hours.txt");
    List<wages> wagesList = new List<wages>();
    foreach (string line in LinesInFile)
    {
        wagesList.Add(new wages() { WorkingHour = int.Parse(line) });
    }
    
    // Display the details
    Console.WriteLine("hours     pay");
    foreach (wages wage in wagesList)
    {
        Console.WriteLine(wage.ToString());// overrided method will give you the formated string
    }
    Console.WriteLine("Average Pay : {0}", wagesList.Average(x => x.AmountToPay));
