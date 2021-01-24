            static DB[] users = new DB[10];
    
            static void Main (string[] args)
            {
                //user 1
                Registration ();
                //user 2
                Registration ();
                
            }
           
            private static void Registration ()
            {
                Console.WriteLine ("=====REGISTER=====");
                Console.Write ("What is your name? ");
                name = (Console.ReadLine ());
                Console.Write ("How old are you? ");
                age = (int.Parse (Console.ReadLine ()));
                Console.Write ("What is your gender? M for Male, F for Female");
                gender = (Console.ReadLine ());
    
                int i = 0;
                while (users.Length > i && users[i] != null)
                {
                    i++;
                }
                if (users.Length > i)
                 {
                   users[i] = new DB ();
                   users[i].SaveData (name, age, gender);
                 }
            }
