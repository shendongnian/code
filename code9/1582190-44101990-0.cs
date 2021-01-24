        public static bool NextBool(this Random random, double probability = 0.5)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return random.NextDouble() <= probability;
        }
