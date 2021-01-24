    static void Main(string[] args)
    {
        List<Ring> rings = new List<Ring>();
        rings.Add(new Ring { Id = 1, Name = "siauliai", Metalas = "s" });
        rings.Add(new Ring { Id = 2, Name = "kaunas", Metalas = "k" });
        rings.Add(new Ring { Id = 3, Name = "vilnius", Metalas = "v" });
        rings.Add(new Ring { Id = 4, Name = "klapedia", Metalas = "ka" });
        rings.Add(new Ring { Id = 5, Name = "siauliai", Metalas = "s" });
    
        SaveDataToFile(rings);
    
        Console.ReadKey();
    }
    
    private static void SaveDataToFile(List<Ring> rings)
    {
        using (StreamWriter writer = new StreamWriter(@"Metalai.csv"))
        {
            List<string> ringMetalas = new List<string>();
            writer.WriteLine("Metalai;Duplication");
    
            foreach (var ring in rings)
            {
                if (!ringMetalas.Contains(ring.Metalas))
                {
                    var duplicationCount = rings.Count(r => r.Metalas == ring.Metalas);
                    ringMetalas.Add(ring.Metalas);
                    
                    var mesage = $"{ring.Metalas}";
                    if (duplicationCount > 1)
                        mesage += $";{duplicationCount}";
    
                    writer.WriteLine("{0}", mesage);
                }
            }
        }
    }
