    static void Main(string[] args)
            {
                string myDateString = "Thursday, 12 October 2017";
                //Why use the above just get a new one for today in the correct format
                //Or create your own converter
                DateTime date = DateTime.Now;
               
                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                //or
                var culture = System.Globalization.CultureInfo.CurrentCulture;
    
                string test = currentCulture.ToString();
    
                 Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo(test)));
                Console.ReadLine();
            }
        
