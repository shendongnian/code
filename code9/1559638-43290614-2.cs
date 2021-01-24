    class Player
    {
        private int stat1 = 1;
        private int stat2 = 2;
        public void AdjustProperty(string propName, int adjustmentIncrement)
        {
            if (propName.Equals("stat1", StringComparison.OrdinalIgnoreCase))
            {
                stat1 += adjustmentIncrement;
            }
            else if (propName.Equals("stat2", StringComparison.OrdinalIgnoreCase))
            {
                stat2 += adjustmentIncrement;
            }            
        }
    }
