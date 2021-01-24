        static void Main(string[] args)
        {
            int number = 35;
            List<int> list = new List<int>();
            int count3 = 0;
            int count5 = 0;
            int step3 = 3;
            int step5 = 5;
            while (count3 < number || count5<number )
            {
                if ((count3 + step3) <= (count5 + step5))
                {
                    count3 += step3;
                    if (count3 <= number)
                    {
                        list.Add(count3);
                    }
                }
                else
                {
                    count5 += step5;
                    if (count5 <= number)
                    {
                        list.Add(count5);
                    }
                }
    
            }
            foreach (var l in list)
            {
                Console.WriteLine(l.ToString());
            }
            Console.ReadLine();
        }
