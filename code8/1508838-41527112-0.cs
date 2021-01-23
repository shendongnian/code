    using System;
    
    namespace BurnThatFat
    {
        class Program
        {
            static void Main()
            {
                var g1 = new Gebruikerklasse1() { Naam = "Duncan", Geslacht = "Male", Huidiggewicht = 75, Gebruikersnaam = "DCarr" };
                var g2 = new Gebruikerklasse2() { Naam = "Duncan", Geslacht = "Male", Huidiggewicht = 75, Gebruikersnaam = "DCarr" };
    
                Console.WriteLine(g1);
                Console.WriteLine(g2);
    
                Console.ReadKey();
            }
        }
    
        class Gebruikerklasse1
        {
            public string Naam;
            public string Achternaam;
            public int Leeftijd;
            public string Geslacht;
            public int Huidiggewicht;
            public int Streefgewicht;
            public string Gebruikersnaam;
            public string Wachtwoord;
        }
    
        class Gebruikerklasse2
        {
            public string Naam;
            public string Achternaam;
            public int Leeftijd;
            public string Geslacht;
            public int Huidiggewicht;
            public int Streefgewicht;
            public string Gebruikersnaam;
            public string Wachtwoord;
    
            public override string ToString()
            {
                return string.Format("{0} - {1} - {2} - {3}", Gebruikersnaam, Geslacht, Huidiggewicht, Naam);
            }
        }
    }
