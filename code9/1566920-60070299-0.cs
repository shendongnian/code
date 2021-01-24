            int Function1(int input)
            {
                return 10 * input;
            }
            int Function2(int input)
            {
                return 20 * input;
            }
            int Function3(int input)
            {
                return 30 * input;
            }
            List<int> list = new List<int> { 2, 3 };
            Dictionary<int, Func<int, int>> actions = new Dictionary<int, Func<int, int>>()
            {
               {1, (arg) => Function1(arg)},
               {2, (arg) => Function2(arg)},
               {3, (arg) => Function3(arg)}
            };
            var bag = new ConcurrentBag<int>();
            Parallel.ForEach(actions,  action => { 
                if(action.Key == 2 || action.Key == 3)
                {
                    bag.Add(action.Value.Invoke(3));
                }                
            });
            foreach(var number in bag)
            {
                Console.WriteLine(number);
            }
