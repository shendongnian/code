    const decimal HOURLY_RATE = 2.50m;
    const decimal MAX_FEE = 20.00m; //Capped at S20.00
    // See http://stackoverflow.com/a/556142/7397065 why you should use @ here
    string path = @"C:\your\path\here.txt";
    string stringFromFile = File.ReadAllText(path);
    // Since your array is delimited on whitespace, use null as parameter
    // You also need int's instead of string. So directly convert the results to int.
    // We now make a List(), which also gives you more flexibility.
    // Want to change your delimiter? See https://msdn.microsoft.com/en-us/library/b873y76a(v=vs.110).aspx
    List<int> hours = stringFromFile.Split(null).Select(int.Parse).ToList();
    Console.WriteLine("Hours and fee's parked per person");
    decimal total = 0;
    // Let's change this to a foreach. That's clearer to work with.
    foreach (int parkingTime in hours)
    {
        decimal parkFee = HOURLY_RATE * parkingTime;
        if (parkFee > MAX_FEE)
            parkFee = MAX_FEE;
        total += parkFee;
        Console.WriteLine("Hours: {0}. Parking Fee: {1}", parkingTime, parkFee);
    }
    // We have to use .Count now, since we use List()
    decimal average = total / hours.Count;
    Console.WriteLine("Average = {0}", average.ToString("N2"));
    Console.ReadKey();
