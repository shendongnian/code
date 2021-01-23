       var lines = File
         .ReadLines(@"D:\list.txt");
    
       int count = 0;
    
       foreach (var line in lines) {
         Console.WriteLine("\n number: {0}", line);
         count++;
       }
    
       Console.WriteLine("\n c {0}", count);
       Console.ReadLine();
