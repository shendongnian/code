                DateTime d1 = DateTime.Now;
                DateTime d2 = DateTime.Now.AddDays(1);
    
                if ( d2.CompareTo(d1)>0 )
                    Console.WriteLine("d2>d1");
                else
                    Console.WriteLine("d2<=d1");
