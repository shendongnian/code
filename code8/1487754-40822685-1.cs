       List<Losuj> losowanko = File
         .ReadLines(@"D:\bawmy się\2# apka\Lotto\Lotto\plik.txt")
         .Select(line => line.Split(new string[] { ".", " ", "," }, StringSplitOptions.None))
         .Select(items => { 
            Losuj item = new Losuj() {
              NumerLosowania = Int32.Parse(items[0]),
              JakiDzien      = Int32.Parse(items[2]), 
              JakiMiesiac    = Int32.Parse(items[3]),
              JakiRok        = Int32.Parse(items[4])}; 
    
            for (int i = 5, lo = 0; i < 11; i++, lo++)
              item[lo] = Int32.Parse(items[i]); 
    
            return item;})
         .ToList();  
