    static void Main()
        {
            var count = 0;
            string text = "I am Sangeen Khan and i am friend Jhon. Jhnon is friend of Wasim.     ";
            List<string> Names = new List<string>() {"Sangeen Khan ", "Jhon","Wasim","Alexander","Afridi" };
            List<string> matchedList = new List<string>();
            foreach (var name in Names)
            {
                if(text.Contains(name))
                {
                    text = text.Replace(name, "\"Name\" ");
                    matchedList.Add(name);
                    count++;
                }
            }
            foreach (var name in matchedList)
            {                
                 Console.WriteLine(name);
            }
           
            Console.WriteLine(count);
            Console.WriteLine(text);
            Console.ReadLine();
        }
