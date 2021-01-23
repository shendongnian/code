                int[] inputs = { 1000, 4878 };
                foreach (int input in inputs)
                {
                    Console.WriteLine("+ {0} + {1}", (input & 0xFF).ToString(), (input >> 8).ToString());
                }
