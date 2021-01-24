    public static class Coins
    {
        public static Coin[][] All => new[]
        {
            AllRed,
            AllGreen,
            AllBlue
        };
        public static Coin[] AllRed { get; } =
        {
            RedS, RedD, RedA, RedC, RedY, RedU, RedL, RedJ, RedO
        };
        public static Coin[] AllGreen { get; } =
        {
            GreenG, GreenX, GreenB, GreenH, GreenE, GreenZ, GreenW, GreenP, GreenQ, GreenR, GreenN, GreenI
        };
        public static Coin[] AllBlue { get; } =
        {
            BlueF, BlueT, BlueV, BlueM, BlueK
        };
        public static Coin RedA => new Coin(CoinColor.Red, CoinLetter.A);
        public static Coin RedC => new Coin(CoinColor.Red, CoinLetter.C);
        public static Coin RedD => new Coin(CoinColor.Red, CoinLetter.D);
        public static Coin RedJ => new Coin(CoinColor.Red, CoinLetter.J);
        public static Coin RedL => new Coin(CoinColor.Red, CoinLetter.L);
        public static Coin RedO => new Coin(CoinColor.Red, CoinLetter.O);
        public static Coin RedS => new Coin(CoinColor.Red, CoinLetter.S);
        public static Coin RedU => new Coin(CoinColor.Red, CoinLetter.U);
        public static Coin RedY => new Coin(CoinColor.Red, CoinLetter.Y);
        public static Coin GreenB => new Coin(CoinColor.Green, CoinLetter.B);
        public static Coin GreenE => new Coin(CoinColor.Green, CoinLetter.E);
        public static Coin GreenG => new Coin(CoinColor.Green, CoinLetter.G);
        public static Coin GreenH => new Coin(CoinColor.Green, CoinLetter.H);
        public static Coin GreenI => new Coin(CoinColor.Green, CoinLetter.I);
        public static Coin GreenN => new Coin(CoinColor.Green, CoinLetter.N);
        public static Coin GreenP => new Coin(CoinColor.Green, CoinLetter.P);
        public static Coin GreenQ => new Coin(CoinColor.Green, CoinLetter.Q);
        public static Coin GreenR => new Coin(CoinColor.Green, CoinLetter.R);
        public static Coin GreenW => new Coin(CoinColor.Green, CoinLetter.W);
        public static Coin GreenX => new Coin(CoinColor.Green, CoinLetter.X);
        public static Coin GreenZ => new Coin(CoinColor.Green, CoinLetter.Z);
        public static Coin BlueF => new Coin(CoinColor.Blue, CoinLetter.F);
        public static Coin BlueK => new Coin(CoinColor.Blue, CoinLetter.K);
        public static Coin BlueM => new Coin(CoinColor.Blue, CoinLetter.M);
        public static Coin BlueT => new Coin(CoinColor.Blue, CoinLetter.T);
        public static Coin BlueV => new Coin(CoinColor.Blue, CoinLetter.V);
    }
