            static void Main(string[] args)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    Recursive(i, new List<string>());
                }
                Console.ReadLine();
            }
