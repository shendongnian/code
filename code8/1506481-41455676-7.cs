    public string getString()
            {
                Console.WriteLine("Type starting letter for country name query: ");
                string user = Console.ReadLine();
                a = user.ToUpper();
                return a;
            }
