        public int HandleException(InvalidCastException exp)
        {
            // Put here some real logic. I tested it using line below
            Console.WriteLine(exp.Message);
            return 100;
        }
    
