        public static void Main(string[] args)
        {
            var nums = new List<int>() { 1, 2, 3, 3, 4, 5 };
            Print(nums);
            //REMOVE DUPLIDATED VALUES AT THE LINE BELOW
            nums = nums.Distinct().ToList();
            Print(nums);
            Console.Read();
        }
        public static void Print(List<int> nums)
        {
            foreach (var num in nums)
            {
                Console.Write(num.ToString() + ", ");
            }
            Console.WriteLine();
        }
