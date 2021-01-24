    public class DieGenerator
    {
        private Random rand = new Random();
        public int Roll()
        {
            return rand.Next(1, 7);
        }
    }
