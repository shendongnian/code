    class HelloWorld {
        static void Main() {
            const int height = 5;
            for (int row = 0; row < height; row++)
            {
                int col = 0;
                var spaces = new String(' ', row - col);
                var zeroes = new String('0', ((height - row) * 2 ) -1 );
                Console.WriteLine(spaces + zeroes);
                ++col;
            }
            for(int i = 1; i < height; i++)
            {
                var newString = new String(' ', height -1);
                newString += '|';
                Console.WriteLine(newString);
            }
            Console.WriteLine(new String('=', height *2));
            Console.ReadKey();
        }
        
    }
