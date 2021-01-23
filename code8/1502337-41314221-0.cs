    static void Main(string[] args)
            {
    
                DateTime Current = DateTime.Now;
                Console.WriteLine("Please enter your birth date: ");
                string myBirthDate = Console.ReadLine();
                var birthDate = DateTime.Parse(myBirthDate);
                
               TimeSpan myAge = Current - birthDate;
               Console.WriteLine($"Hours: {myAge.TotalHours}");
               Console.WriteLine($"Days: {myAge.TotalDays}");
               Console.WriteLine($"Years: {Current.Year - birthDate.Year}");
                              
               Console.WriteLine(myAge);
            }
