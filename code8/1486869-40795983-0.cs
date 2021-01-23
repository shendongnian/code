    class Program
    {
        static void Main(string[] args)
        {
            /// This for loop is for keeping the number of rows in pyramid (height) and - 
            /// iterate through each rows to print the pyramid using *
            for(int row=0;row<5;row++)
            {
                /// This loop is used add spaces before *
                /// Core logic - Set number of loop (space max) as number spaces required
                /// Row 1: Adding 4 spaces before * (space max limit = 5 - 0 - 1)
                /// Row 2: Adding 3 spaces before * (space max limit = 5 - 1 - 1)
                /// Row 3: Adding 2 spaces before * (space max limit = 5 - 2 - 1)
                /// And goes on like above pattern
                for (int space=0;space<5-row-1;space++)
                {
                    Console.Write(" ");
                }
                /// This loop is used add *
                /// Building the * pattern, logic in below comments
                /// Core logic - Set number of loop (star max) as number for stars required
                /// First row: Stars required = 1, (star max limit = 0 * 2 + 1 = 1)
                /// Second row: Stars required = 3, (star max limit = 1 * 2 + 1 = 3)
                /// Third row: Stars required = 5, (star max limit = 2 * 2 + 1 = 5)
                /// Fourth row: Stars required = 7, (star max limit = 3 * 2 + 1 = 7)
                /// And goes on like above pattern
                for (int star = 0; star < row * 2 + 1; star++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
