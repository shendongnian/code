        static void Main(string[] args)
        {
            Random random = new Random();
            const int max = 8;
            for (int i = 0; i < 50; i++)
            {
                int[] sequence =
                    GetRandomNonConsecutiveSequence(random, max, 4)
                    .Select(j => j + 2)
                    .ToArray();
                if (!CheckSequence(sequence))
                {
                    Console.WriteLine("Sequence failed: " + string.Join(", ", sequence));
                }
            }
        }
        private static bool CheckSequence(int[] sequence)
        {
            int previous = sequence[0];
            for (int i = 1; i < sequence.Length; i++)
            {
                if (previous == sequence[i])
                {
                    return false;
                }
                previous = sequence[i];
            }
            return true;
        }
        private static IEnumerable<int> GetRandomNonConsecutiveSequence(
            Random random, int max, int count)
        {
            int previous = random.Next(max);
            yield return previous;
            while (--count > 0)
            {
                yield return previous = Next(previous, max, random);
            }
        }
        static int Next(int previous, int max, Random random)
        {
            return (previous + random.Next(max - 1) + 1) % max;
        }
