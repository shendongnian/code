            int[] array = new int[] { 7, 5, 6 };
            int startPosition = 1;
            string result = "";
            // Run from the start position to the end of the array
            for (int i = startPosition;  i < array.Length; i++)
            {
                result += array[i] + ",";
            }
            // Wrapping around, run from the beginning to the start position
            for (int i = 0; i < startPosition; i++)
            {
                result += array[i] + ",";
            }
            // Output the results
            result = result.TrimEnd(',');
            Console.WriteLine(result);       
            Console.Read();
