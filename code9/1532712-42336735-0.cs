    class Program
    {
        static void Main(string[] args)
        {
            string sub; /*1. Remove this line*/
            // string brd;
            brd = board();
            sub = subjects(); /*2. string[] sub = subjects();*/
            //Console.WriteLine(brd);
            Console.WriteLine(sub);
            Console.ReadLine();
        }
        public static string[] subjects()
        {
            Console.WriteLine("Please Enter How many Subject Do you Want to input");
            int limit = System.Convert.ToInt32(Console.ReadLine());
            string[] Subjects = new string[limit];
            int[] index = new int[limit]; /*3. Remove this line -> Redundant*/
            /*4. Change variable `limit` to `i`*/
            for (int i = 0; i <= limit; i++)
            {
                Console.WriteLine("Please Enter Subject Name " + i + 1);
                Subjects[i] = Console.ReadLine();
            }
            return Subjects;
        }
    }
