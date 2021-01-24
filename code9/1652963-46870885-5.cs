    class HelloWorld {
        static void Main() {
            const int height = 1 ;
            for (int row = 0; row < height; row++)
            {
                var spaces = new String(' ', row);
                var zeroes = new String('0', ((height - row) * 2 ) -1 );
                Console.WriteLine(spaces + zeroes);
            }
            for(int i = 1; i <= height; i++)
            {
                var spaces = new String(' ', height -1);
                Console.WriteLine(spaces + '|');
            }
            Console.WriteLine(new String('=', (height *2) -1));
            Console.ReadKey();
        }
        
    }
