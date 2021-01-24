            int[] pointsArr = new int[4];
            int arraySize = pointsArr.Length;
            int i = 0;
            while (i < arraySize)
            {
                try
                {
                    Console.WriteLine("Input coordinates:");
                    float x = float.Parse(Console.ReadLine());
                    float y = float.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Illegal value, please re-input");
                    continue;
                }
                i++;
            }
            Console.ReadLine();
