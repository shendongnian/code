    class CommonChest : BasicKeyChest
    {
        public CommonChest() : base(DoSomething())
        {
           
        }
    
        private static string DoSomething()
        {
            Random rnd = new Random();
            int key = rnd.Next(1, 6);
            int coins = rnd.Next(70, 121);
            return Tuple.Create(key, coins);
        }
    }
