    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Säljare> salesmen = new List<Säljare>();
    
            var nivaMax = 0;
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Var Vänlig och skriv in info för säljaren (1,Namn (enter),2, persnr (enter),3, Distrikt(enter),4, AntalArtiklar (enter), 5,Niva 1-4(enter)");
                var saljare = new Säljare(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                nivaMax = Math.Max(nivaMax , saljare.NIVA);
                salesmen.Add(saljare);
            }
    
            //We're telling the GroupBy method what we want to 'group by'
            //this is the 'LINQ' part.
            foreach (var nivaGruppe in salesmen.GroupBy(x => x.NIVA))
            {
                var groupNivå = nivaGruppe.Key;
                var howManyInGroup = nivaGruppe.Count();
                Console.WriteLine("{0} salesmen have reached nivå {1}", howManyInGroup, groupNivå);
            }
    
            Console.WriteLine("------------------------------------------");
    
            for (int level = 0; level < nivaMax; level++)
            {
                var salesmenAtLevel = 0;
                foreach (Säljare saljare in salesmen)
                {
                    if (saljare.NIVA == level)
                    {
                        salesmenAtLevel++;
                    }
                }
                if (salesmenAtLevel > 0)
                {
                    Console.WriteLine("{0} salesmen have reached nivå {1}", salesmenAtLevel, level);
                }
            }
    
            Console.ReadKey(true);
        }
    }
