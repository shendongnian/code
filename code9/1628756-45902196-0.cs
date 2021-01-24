    namespace RandomArray
    {
        class RandomArrayNoDuplicates
        {
            static Random rng = new Random(DateTime.Now.Millisecond);
            static int size = 45;
    
            static void Main(string[] args)
            {
                int[] array = InitializeArrayWithNoDuplicates(size);
                DisplayArray(array);
                Console.ReadLine();
            }
            /// <summary>
            /// Creates an array with each element a unique integer
            /// between 1 and 45 inclusively.
            /// </summary>
            /// <param name="size"> length of the returned array < 45
            /// </param>
            /// <returns>an array of length "size" and each element is
            /// a unique integer between 1 and 45 inclusive </returns>
            public static int[] InitializeArrayWithNoDuplicates(int size)
            {
                int[] allNos = new int[size];
                bool[] used = new bool[size];
    
                for (int i = 0; i < size; i++)
                {
                    allNos[i] = i + 1;
                    used[i] = false;
                }
    
                int[] arr = new int[size];
                int max = size;
    
                for (int i = 0; i < size - 1; i++)
                {
                    int number = rng.Next(0, max);
                    int ptr = 0;
                    for (int j = 0; j < size; j++)
                    {
                        if (used[j])
                        {
                            ptr++;
                        }
                        else
                        {
                            if (j == number + ptr)
                            {
                                break;
                            }
                        }
                    }
                    arr[i] = allNos[number + ptr];
                    used[number + ptr] = true;
                    max--;
                }
                for (int i = 0; i < size; i++)
                {
                    if (used[i] == false)
                    {
                        arr[size - 1] = allNos[i];
                        break;
                    }
                }
    
                return arr;
            }
            public static void DisplayArray(int[] arr)
            {
                for (int x = 0; x < size; x++)
                {
                    Console.WriteLine(arr[x]);
                }
            }
        }
    }
