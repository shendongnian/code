        public static void InsertionSort<T>(T[] array)
            where T : IComparable<T>
        {
            T temp;
            int j;
            for (int i = 1; i < array.Length; i++)
            {
                temp = array[i];
                j = i - 1;
                while (j >= 0 && array[j].CompareTo(temp) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
