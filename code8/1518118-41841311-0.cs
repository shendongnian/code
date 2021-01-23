    var starttime = DateTime.Now;
                var someLongDataString = new StringBuilder(100000);
                const int sLen = 30, loops = 50000;
                var source = new string('X', sLen);
                
    
                Console.WriteLine();
                for (var i = 0; i < loops; i++)
                {
                    someLongDataString.Append(source);
                }
    
                Console.WriteLine((DateTime.Now - starttime).Milliseconds);
                Console.ReadLine();      
     
