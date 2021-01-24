    int[] hours = new int[30]{ 8, 24, 9, 7, 6, 12, 10, 11, 23, 1, 2, 9, 8,  8, 9, 7, 9, 15, 6, 1, 7, 6, 12, 10, 11, 23, 1, 2, 9, 8 };
    const decimal HOURLY_RATE = 2.50m;
    const decimal MAX_FEE = 20.00m; //Capped at S20.00
    Console.WriteLine("Hours and fee's parked per person");
    int total = 0;
    for (int index = 0; index < hours.Length; index++)
    {
        decimal parkFee = HOURLY_RATE * hours[index];
        if (parkFee > MAX_FEE)
            parkFee = MAX_FEE;
        total += parkFee;
        Console.WriteLine("Hours: {0}. Parking Fee: {1}", hours[index], parkFee);      
    }
    double average = (double)total / hours.Length;
    Console.WriteLine("Average = " + average.ToString("N2"));
    Console.ReadKey();`
