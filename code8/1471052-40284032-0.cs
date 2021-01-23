        static void Main(string[] args)
        {
            int[] array = {8, 3, 4, 5, 9, 12, 6, 3, 5};
            int[] subArray = {3, 4, 5};
            int arrayLength = array.Length;
            int subArrayLength = subArray.Length;
            ArraySegment<int> segment = new ArraySegment<int>();
            bool found = false;
            for (int i = 0; i < arrayLength - subArrayLength; i++)
            {
                segment = new ArraySegment<int>(array, i, subArrayLength);
                // look for sub array
                int nbFound = 0;
                for (int j = 0; j < subArrayLength; j++)
                {
                    if (segment.Array[segment.Offset + j] == subArray[j])
                        ++nbFound;
                    else
                        break;
                }
                // sub array found
                if (nbFound == subArrayLength)
                {
                    found = true;
                    break;
                }
            }
            
            if (found)
            {
                int[] result = new int [arrayLength - subArrayLength];
                Array.Copy(array, 0, result, 0, segment.Offset + 1);
                Array.Copy(array, segment.Offset + subArrayLength, result, segment.Offset + 1, arrayLength - 1 - segment.Offset - subArrayLength);
                Console.WriteLine($"Result : {string.Join(", ", result)}");
            }
            else
            {
                Console.WriteLine($"Result : {string.Join(", ", array)}");
            }
            Console.ReadKey();
        }
