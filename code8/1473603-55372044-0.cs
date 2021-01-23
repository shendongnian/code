             string pass = "";
            
            while (pass != "password")
            {
                Console.WriteLine("enter your password here");
                pass = Convert.ToString(Console.ReadLine());
                if (pass == "password")
                {
                    Console.WriteLine("your password is correct");
                }
          }
            Console.ReadKey();
