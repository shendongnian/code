    public class Program
    {
        static void Main(string[] args)
        {
            var sampleResult2 = BruteForceCombinations(new List<int>(), new List<Combination>());
            foreach (var result in sampleResult2)
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
        private static IEnumerable<Combination> BruteForceCombinations(List<int> listSoFar = null, List<Combination> validCombinations = null)
        {
            if (listSoFar.Count == 9)
            {
                if (listSoFar.Sum() == 100)
                {
                    List<int> validCombinationList = new List<int>();
                    validCombinationList.AddRange(listSoFar);
                    validCombinations.Add(new Combination(validCombinationList));
                }
            }
            else
            {
                // Run from 0 to 100 - the sum of list entries so far + 1, as any number larger than that will create a sum larger than 100
                for (int i = 0; i < 100 - listSoFar.Sum() + 1; i++)
                {
                    // Add the number to test the combination and remove after
                    // The combination is added if we hit one that sums to 100.
                    listSoFar.Add(i);
                    BruteForceCombinations(listSoFar, validCombinations);
                    listSoFar.RemoveAt(listSoFar.Count-1);
                }
            }
            return validCombinations;
        }
    }
    public class Combination
    {
        private readonly List<int> numbers; 
        public Combination(List<int> numbers)
        {
            this.numbers = numbers;
        } 
        public override string ToString()
        {
            return string.Join(";", this.numbers);
        }
    }
