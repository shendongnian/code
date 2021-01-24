    class Program
    {
        private static Dictionary<long, string> list = new Dictionary<long, string>();
        static void Main(string[] args)
        {
            bool menu = true; 
            while (menu)
              {
                 menu = Menu();
              } 
        }
        public static bool Menu()
        {
            Person person = new Person();
            int choice;
            Console.WriteLine("1. Add person");
            Console.WriteLine("2. Delete person");
            Console.WriteLine("3. Save data to text file");
            Console.WriteLine("4. Exit");
            choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    person.createPerson();
                    var personInfoKey = string.Format("{0} {1} {2} {3}", person.firstName, person.lastName, person.Gender, person.dateOfBirth); 
                    list.Add(person, personInfoKey );
                    return true;
                case 2:
                    person.removePeople();
                    list.Remove(person);
                    return true;
                case 3:
                    person.saveToFile();
                    return true;
                case 4:
                    return false;
                default:
                    return true;
            }
    
        }
    }
    class Person
    {
        private long choiceOfPerson = 0;
        private string completeInfo = "";
        public string firstName { get; set; }
        public string lastName { get; set; }
        public long personalIdentityNumber { get; set; }
        public string Gender { get; set; }
        DateTime dateOfBirth = new DateTime();
    
        public void createPerson()
        {
            Console.WriteLine("Enter personal identity number");
            personalIdentityNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your first Name");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter your gender");
            Gender = Console.ReadLine();
            Console.WriteLine("Enter your date of birth: DD/MM/YYYY");
            bool error = true;
            {
                while (error)
                    try
                    {
                        dateOfBirth = DateTime.Parse(Console.ReadLine());
                        error = false;
                    }
                    catch (FormatException fEx)
                    {
                        Console.WriteLine(fEx.Message);
    
                    }
            }
            completeInfo = firstName + " " + lastName + " " + Gender + " " + dateOfBirth.ToString("dd/MM/yyyy");
            list.Add(personalIdentityNumber, completeInfo);
        }
        public void removePeople()
        {
            foreach (KeyValuePair<long, string> entry in list)
            {
                Console.WriteLine(completeInfo + " " + personalIdentityNumber);
            }
            Console.WriteLine("Write the perosnal identity number of person you wish to delete");
            choiceOfPerson = long.Parse(Console.ReadLine());
            list.Remove(choiceOfPerson);
        }
        public void saveToFile()
        {
            foreach (KeyValuePair<long, string> entry in list)
            {
                File.WriteAllText(@"E:\gry\info2.txt", completeInfo + personalIdentityNumber);
            }
        }
    }
