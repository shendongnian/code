     int[] arr = new[] { 10, 5, 5, 6, 4, 5, 7, 3, 8, 2 };
            int key = 1;
            int sumOfIndexes = 11 - key;
            // Number of combinations (2^n-1)
            int NumOfCombinations =(int) Math.Pow(2, arr.Length) - 1;
            // Result
            List<List<int>> listOfCombinations = new List<List<int>>();
            for (int i = 0; i < NumOfCombinations; i++)
            {
                int[] massBits = new int[arr.Length];
                // Convert index to binary
                int indexOfMass = i;
                for(int j = 0; indexOfMass > 0 ; j++)
                {
                    int remainder = indexOfMass % 2;
                    indexOfMass /= 2;
                    massBits[j] = remainder;
                }
                // Take indexes of elements, which contains 1
                var elementToCombine = massBits.Select((bit, j) => bit == 1 ? j: -1).Where(index=>index != -1).ToList();
                // Sum all elements 
                int resultSum = elementToCombine.Sum(index => arr[index]);
                if (resultSum != sumOfIndexes) continue;
                listOfCombinations.Add(elementToCombine);
            }
            foreach (var list in listOfCombinations)
            {
                foreach (var el in list)
                {
                    Console.Write(el + " ");
                }
                Console.WriteLine();
            }
