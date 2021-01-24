    internal class Test
    {
        public Test()
        {
            var allGood = new[,]
            {
                {Coins.RedS, Coins.RedD, Coins.RedA},
                {Coins.GreenG, Coins.GreenX, Coins.GreenB},
                {Coins.BlueF, Coins.BlueT, Coins.BlueV}
            };
            var allFalse = new[,]
            {
                {Coins.RedS, Coins.RedS, Coins.RedA},
                {Coins.GreenG, Coins.GreenG, Coins.GreenB},
                {Coins.BlueF, Coins.BlueF, Coins.BlueV}
            };
            foreach (var grid in new[] {allGood, allFalse})
            {
                var game = new Game(grid);
                var check = game.Check();
                Console.WriteLine(check);
            }
        }
    }
