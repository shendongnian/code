    public static Cycles
    {
        public static While(Func<bool> condition, Action body, CancellationToken token)
        {
            while(!token.IsCancellationRequested && condition())
            {
                body();    
            }
        }
    }
