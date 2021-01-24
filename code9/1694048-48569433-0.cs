        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            char[] number_char = number.ToArray();
            int sum = 0;
            foreach (var item in number_char)
            {
                sum += Convert.ToInt32(item.ToString());
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
