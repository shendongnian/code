            for (int i = 0; i < array.Length; i = i + 1)
            {
                while (!int.TryParse(Console.ReadLine(), out array[i]))
                    Console.WriteLine("Input an integer value!");                    
            }
            if (array[1] == 0)
            {
                Console.WriteLine("Alert!");
            }
