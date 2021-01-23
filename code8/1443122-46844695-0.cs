    class Program
    {
        private bool _running = true;
        static void Main(string[] args)
        {
            Program program = new Program();
            while (program._running)
            {
                PlaceOrders();
                ...
                if (exitCondition)
                {
                    program._running = false;
                }
            }
        }
    }
