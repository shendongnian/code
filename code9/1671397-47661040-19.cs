    using System.Linq;
    ...
    // See how it's easy (the third problem in the question):
    static Verkauf[] FindeVerkäufe(Verkauf[] arr, string farbe) {
      return arr
        .Where(stuck => stuck.Farbe == farbe)
        .ToArray();  
    }
    ...
    string farbe = "Rot";
    double max = alle
      .Where(stuck => stuck.Farbe == farbe)
      .Max(stuck => stuck.StückPreis); 
    double min = alle
      .Where(stuck => stuck.Farbe == farbe)
      .Min(stuck => stuck.StückPreis); 
    Console.WriteLine(
      $"Farbe {farbe}: Verkäufe mit kleinsten Preis {min.StückPreis} Verkäufe mit größten Preis {max.StückPreis}");
