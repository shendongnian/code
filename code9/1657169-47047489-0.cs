           Console.WriteLine ("=====REGISTER=====");
            var users = new DB[10];
            for (int i = 0; i < users.Length; i++)
            {
                //input data
                Console.Write ("What is your name? ");
                name = (Console.ReadLine ());
                Console.Write ("How old are you? ");
                age = (int.Parse (Console.ReadLine ()));
                Console.Write ("What is your gender? M for Male, F for Female");
                gender = (Console.ReadLine ());
                // store data
                users[i] = new DB (name);
                users[i].SaveData (name, age, gender);
            }
