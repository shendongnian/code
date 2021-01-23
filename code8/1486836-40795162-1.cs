    // Dictionary from (car,length,band) to rate
    static readonly Dictionary<Tuple<int, int, string>, decimal> rates =
      new Dictionary<Tuple<int, int, string>, decimal>
      {
        { Tuple.Create(49, 6, "AA"), 44m },
        { Tuple.Create(49, 6, "A"), 60.5m },
        { Tuple.Create(49, 6, "B"), 71.5m },
        { Tuple.Create(49, 6, "C"), 82.5m },
        { Tuple.Create(49, 6, "D"), 88m },
        { Tuple.Create(49, 12, "AA"), 80m },
        { Tuple.Create(49, 12, "A"), 110m },
        { Tuple.Create(49, 12, "B"), 130m },
        { Tuple.Create(49, 12, "C"), 150m },
        { Tuple.Create(49, 12, "D"), 160m },
        { Tuple.Create(48, 6, "AA"), 38.5m },
        { Tuple.Create(48, 6, "A"), 55m },
        { Tuple.Create(48, 6, "B"), 66m },
        { Tuple.Create(48, 6, "C"), 77m },
        { Tuple.Create(48, 6, "D"), 85.25m },
        { Tuple.Create(48, 12, "AA"), 70m },
        { Tuple.Create(48, 12, "A"), 100m },
        { Tuple.Create(48, 12, "B"), 120m },
        { Tuple.Create(48, 12, "C"), 140m },
        { Tuple.Create(48, 12, "D"), 155m },
        { Tuple.Create(59, 6, "AA"), 33m },
        { Tuple.Create(59, 6, "A"), 49.5m },
        { Tuple.Create(59, 6, "B"), 60.5m },
        { Tuple.Create(59, 6, "C"), 71.5m },
        { Tuple.Create(59, 6, "D"), 82.5m },
        { Tuple.Create(59, 12, "AA"), 60m },
        { Tuple.Create(59, 12, "A"), 90m },
        { Tuple.Create(59, 12, "B"), 110m },
        { Tuple.Create(59, 12, "C"), 130m },
        { Tuple.Create(59, 12, "D"), 150m },
      };
      
    static void Main()
    {
      Console.WriteLine("Diesel Car   Petrol Car   Alt. Fuel Car");
      Console.WriteLine("TC 49        TC 48        TC 59");
      Console.WriteLine("Enter Car Type (TC #): ");
      int car;
      if (!int.TryParse(Console.ReadLine(), out car))
      {
        Console.WriteLine("Error");
        return;
      }
      Console.WriteLine("Enter Licience length in months(6 or 12)");
      int length;
      if (!int.TryParse(Console.ReadLine(), out length))
      {
        Console.WriteLine("Error");
        return;
      }
      Console.WriteLine("Enter Emission Band (AA, A, B, C, D): ");
      string band = Console.ReadLine();
      
      var key = Tuple.Create(car, length, band);
      decimal rate;
      if (!rates.TryGetValue(key, out rate)
      {
        Console.WriteLine("Error finding rate for " + key);
        return;
      }
      Console.WriteLine("rate");
    }
