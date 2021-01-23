       static void Main(string[] args)
            {
                List<DateTime> list = new List<DateTime>()
                {
                     DateTime.Parse("10/01/2016 4:00 PM") ,
                     DateTime.Parse("10/01/2016 11:00 AM"),
                     DateTime.Parse("10/01/2016 12:00 PM")
                };
    
                Console.WriteLine(list.Max());
                Console.ReadKey();
            }
