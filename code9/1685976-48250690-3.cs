        static void elementsOfArray1(string[] array)
        {
            string[] array1 = new string[array.Length];
            int i;
            for (i = 0; i < array.Length - 1; i++)
                Console.Write(array[i] + ",");
           // Console.WriteLine(array[i]);
        }
