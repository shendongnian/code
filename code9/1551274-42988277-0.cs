        static void Main(string[] args)
        {
            var dic = new Dictionary<int, int>();
            Console.Write("Enter Size of the Array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the elements of an Array: ");
            for (int i = 0; i < size; i++)
            {
                int val = Convert.ToInt32(Console.ReadLine());
                
                int current;
                if (dic.TryGetValue(i, out current))
                {
                    dic[val] = current + 1;
                }
                else
                {
                    dic.Add(val, 1);
                }
            }
            foreach (int key in dic.Keys)
            {
                Console.WriteLine(key + " Occurs " + dic[key] + " Times.");
            }
            Console.Read();
        }
