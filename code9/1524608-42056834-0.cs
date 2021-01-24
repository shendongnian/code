            int[] numbers = new int[]{ 1, 4, 3, 5, 7, 9 };
            int i = 0;
            foreach (int item in numbers)
            {
                numbers[i] = 2;
                i++;
            }
            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }
