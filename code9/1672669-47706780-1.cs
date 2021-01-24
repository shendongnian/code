    public class MatchPlay
    {
        public void Match()
        {
            // Add three Die objects to our list of dice
            List<Die> dice = new List<Die>
            {
                new Die(), new Die(), new Die()
            };
            Console.WriteLine("Starting Match Play...");
            Console.WriteLine();
            Console.WriteLine("Round One");
            // Roll all dice
            dice.ForEach(d => d.Roll());
            Console.WriteLine("Your first dice is {0}", dice[0].Value);
            Console.WriteLine("Your second dice is {0}", dice[1].Value);
            Console.WriteLine("Your third dice is {0}", dice[2].Value);
        }
    }
