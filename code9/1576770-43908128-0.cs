        private static decimal GetVelocity()
        {
            Regex regex = new Regex(@"^[0-9]([.,][0-9]{1,3})?$");
            Console.Write("Please enter the intial velocity of the object: ");
            string decimalInput = Console.ReadLine();
            while (!regex.IsMatch(decimalInput))
            {
                Console.WriteLine("Wrong input");
                decimalInput = Console.ReadLine();
            } 
            decimal mVelocity = decimal.Parse(decimalInput);
            return mVelocity;
        }
