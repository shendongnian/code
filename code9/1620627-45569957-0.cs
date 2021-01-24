     public void Sok()
        {
            Console.Clear();
            Console.WriteLine("{0}SEARCH{1}", l, r);
            Console.WriteLine("SKRIV [BACK] FÖR ATT GÅ TILL HUVUDMENYN");
            Console.Write("SÖK EFTER ADRESS, PORTKOD ELLER HUSNUMMER:");
            var InputAdress = Console.ReadLine().Trim().ToUpper();
            foreach (string line in System.IO.File.ReadAllLines(filePath))
            {
                if (line.Contains(InputAdress))
                {
                    string[] entries = line.Split(',');
                    Adress Searching = new Adress();
                    Searching.Adresses = entries[0];
                    Searching.HusNummer = entries[1];
                    Searching.PortKod = entries[2];
                    Adresser.Add(Searching);
                    Console.WriteLine("{0}FOUND{1}",l, r);
                    Console.WriteLine("|ADRESS: {0}", Searching.Adresses);
                    Console.WriteLine("|NUMMER: {0}", Searching.HusNummer);
                    Console.WriteLine("|PORTKD: {0}", Searching.PortKod);
                    
                }
                else if (InputAdress == "BACK")
                {
                    Console.Clear();
                    Console.WriteLine("{0}BACK{1}", l, r);
                    Console.WriteLine("ÅTERGÅR TILL HUVUDMENYN OM 1SEK.");
                    Console.WriteLine("{0}BACK{1}", l, r);
                    System.Threading.Thread.Sleep(1500);
                }
            }
            Console.WriteLine("{0}{1}", l, r);
            Console.ReadKey();
        }
