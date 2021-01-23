                int[] array = { 3, 7, 9, 7, 4, 9, 7, 9 };
                int length = array.Length;
                int Maxvalue = array.Max();
                int[] FrequentArray = new int[Maxvalue + 1];
                for (int i = 0; i < length; i++)
                {
                    FrequentArray[array[i]]++;
                }
                for (int i = 0; i < Maxvalue + 1; i++)
                {
                    if (FrequentArray[i] > 2)
                    {
                        Console.WriteLine(i);
                    }
                }
