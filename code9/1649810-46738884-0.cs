        public abstract class MyAbstract
        {
            static readonly int my_val;
            static MyAbstract()
            {
                my_val = CalculateMyVal();
            }
    
            static int CalculateMyVal()
            {
                int x = 1;
                // Long Calculation on x
                return x;
            }
        }
