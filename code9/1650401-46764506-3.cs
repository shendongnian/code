        public void function(ref int abc)
        {
            Console.WriteLine("Result Ref: " + abc);
        }
        public void function(out int abc)
        {
            abc = 1221;
            Console.WriteLine("Result Out: " + abc);
        }
