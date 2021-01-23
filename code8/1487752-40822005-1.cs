        using(StreamReader file =
               new StreamReader(@"D:\bawmy się\2# apka\Lotto\Lotto\plik.txt"))
        {
           while ((line = file.ReadLine()) != null)
           {
            Losuj pomocnik = new Losuj();
            // Console.WriteLine(line);
            string[] podzialka = line.Split(new string[] { ".", " ", "," }, StringSplitOptions.None);
            pomocnik.NumerLosowania = Int32.Parse(podzialka[0]);
            pomocnik.JakiDzien = Int32.Parse(podzialka[2]);
            pomocnik.JakiMiesiac =Int32.Parse(podzialka[3]);
            pomocnik.JakiRok=Int32.Parse(podzialka[4]);
              for (int i = 5, lo=0; i < 11; i++,lo++)
            {
                pomocnik.Los[lo] =Int32.Parse(podzialka[i]);
            }
            losowanko.Add(pomocnik);
          }
        }
