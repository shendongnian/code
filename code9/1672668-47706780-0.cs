    public class Die
    {
        public int Value { get; set; }
        // Make this static and instantiate it only once to avoid re-seeding issues
        private static readonly Random rnd = new Random();
        public Die()
        {
            Value = 1;
        }
        public void Roll()
        {
            // This method uses values 1-6 as a standard die
            Roll(1, 6);
        }
        public void Roll(int minValue, int maxValue)
        {
            Value = rnd.Next(minValue, maxValue + 1);
        }
    }
