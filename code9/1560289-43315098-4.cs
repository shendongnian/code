    Console.WriteLine("hours     pay");
    decimal sumOfPay = 0;
    for (int i = 0; i < hours.Length; i++)
    {
        pay = Math.Min(hours[i] * HOURLY_RATE, MAX_FEE);
        sumOfPay += pay;
        Console.WriteLine("{0,4} {1,10}", hours[i], pay.ToString("C"));
    }
    Console.WriteLine("Average Pay : {0}", sumOfPay / hours.Length );
