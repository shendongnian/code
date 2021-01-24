     static void Main(string[] args)
        {
            var i = GetNumberFromUser();
            Console.Write(i);
            Console.Read();
        }
        static int GetNumberFromUser()
        {
            int userNumber = 0;
            while (userNumber < 1 || userNumber > 10)
            {
                Console.Write("Enter a number between 1 and 10: ");
                string usersResponse = Console.ReadLine();
                userNumber = Convert.ToInt32(usersResponse);
            }
            return userNumber;
        }
