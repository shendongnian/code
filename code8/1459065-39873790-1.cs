    private static void sort()
            {
                int[] array = new int[3];
                int order = array[0];
                Console.WriteLine("plz enter 3 numbers");
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = int.Parse(Console.ReadLine());
    
                    Array.Sort(array);
                    Array.Reverse(array);
                    Console.WriteLine("the number in order  ", array[i]);
                }
    
                Console.ReadKey();
            }
