     class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Program 202t";
            Console.Write("Enter the first day of the month: ");
            int startingDay = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number of days in a month: ");
            int daysInMonth = Convert.ToInt32(Console.ReadLine());
            List<string> daysOfTheWeek = new List<string>() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
            foreach (string day in daysOfTheWeek)
            {
                Console.Write($"{day,10}");
            }
            List<string> days = new List<string>();
            for (int i = 0; i < startingDay; i++)
            {
                days.Add($"{"",10}");
            }
            for (int i = 1; i < daysInMonth+1; i++)
            {
                days.Add($"{i,10}");
            }
            for (int i = 0; i < days.Count; i++)
            {
                if (i%7!=0) {Console.Write(days[i]);}
                else {Console.WriteLine(days[i]);}                
            }
            
        }
