    class Customer
    {
        public string fName, lName;
        public Customer()
        {
            Console.WriteLine("Please enter your first name");
            fName = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            lName = Console.ReadLine();
            Console.WriteLine(ToString());
        }
    
        public override string ToString()
        {
            return fName + lName;
        }
    }
