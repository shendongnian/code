    static void Main(string[] args)
            {
                List<string> list = new List<string>();
                list.Add("join");
                list.Add("website");
                list.Add("free");
                list.Add("credit");
                list.Add("www.");
                list.Add(".com");
    
                var count = 0;
    
                string Message = "Join this website today, free credits and much more! www.site.com";
    
                foreach (var Filter in list)
                {
                    if (Message.ToLower().Contains(Filter))
                    {
                        Console.WriteLine(Filter);
                        count++;
                    }
                }
    
                if (count>=3)
                {
                    Console.WriteLine("\n\n\nTRUE");
                }
                else
                {
                    Console.WriteLine("\n\n\nFALSE");
                }
    
                Console.ReadLine();
            }
