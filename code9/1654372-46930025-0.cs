            static void Main(string[] args)
            {
                int[] draw = new int[] { 3, 33, 12, 34, 15 };
                var groups = draw.GroupBy(x => (int)((x - 1) / 10)).ToList();
                for (int i = 0; i < 10; i ++)
                {
                    if(!groups.Where(x => x.Key == i).Any())
                    {
                        Console.WriteLine("Does not contain number between {0} and {1}", (10 * i) + 1, (10 * i) + 10);
                    }
                }
                Console.ReadLine();
     
            }
