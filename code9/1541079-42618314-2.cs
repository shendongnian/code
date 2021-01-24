    class Calculator
    {
        int sum = 0;
    
        public void Add(int a)
        {
            sum += a;
        }
    
        public void Subtract(int a)
        {
            sum -= a;
        }
    
        public int GetTotal()
        {
            return sum;
        }
    }
