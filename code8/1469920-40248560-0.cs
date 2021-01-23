    	   const string command = "echo";
            var input = Console.ReadLine();
                      
            if (input.IndexOf(command) != -1)
            {                
                var index = input.IndexOf("echo");               
                var newInputInit = input.Substring(0, index);
                var newInputEnd = input.Substring(index + command.Length);
                var newInput = newInputInit + newInputEnd;
                Console.WriteLine(newInput);
            }
            Console.ReadKey();
