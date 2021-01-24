    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate person object
            var person = new Person();
            //Give it a default name
            person.Name = "Andrew";
            //Register to the nameChangedEvent, and tell it what to do if the person's name changes
            person.nameChangedEvent += (sender, nameChangedArgs) =>
            {
                Console.WriteLine(nameChangedArgs.NewName);
            };
            //This will trigger the nameChanged event.
            person.Name = "NewAndrewName";
            Console.ReadKey();
        }
    }
