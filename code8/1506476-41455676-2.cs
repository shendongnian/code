    public class country
            {
                public string name { get; set; }
                public string capital { get; set; }
                public int population { get; set; }
    
                public country(string n, string c, int p)
                {
                    name = n;
                    capital = c;
                    population = p;
                    Console.WriteLine("Country Name: " + n + " Capital: " + c + " Population: " + p);
                }
    
                public void Print()
                {
                    Console.WriteLine("Country Name: " + name + " Capital: " + capital + " Population: " + population);
                }
            }
