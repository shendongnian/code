    class CommonChest : BasicKeyChest {
        public CommonChest()
        :   this(GenTuple()) {
        }
        private CommonChest(Tuple<int,int> keysCoins)
        :   base(keysCoins.Item1, keysCoins.Item2, "Common") {
        }
        private static Tuple<int,int> GenTuple() {
            Random rnd = new Random();
            int keys = rnd.Next(1, 6);
            int coins = rnd.Next(70, 121);
            return Tuple.Create(keys, coins);
        }
    }
