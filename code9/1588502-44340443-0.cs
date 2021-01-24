     static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separate by hypen : ");
            var name = Console.ReadLine();
            int[] numarray = Array.ConvertAll(name.Split('-'), int.Parse); 
            if (IsSequential(numarray))
            {
                Console.WriteLine("Consecutive");
            }
            else
            {
                Console.WriteLine("Not Consecutive");                 
            }
        }
        static bool IsSequential(int[] array)
        {
            return array.Zip(array.Skip(1), (a, b) => (a + 1) == b).All(x => x);
        }
