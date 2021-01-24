    public class RandomlyDistributesNumbersTotallingTarget
    {
        public IEnumerable<int> GetTheNumbers(int howManyNumbers, int targetTotal)
        {
            var random = new Random();
            var distributions = new List<double>();
            for (var addDistributions = 0; addDistributions < howManyNumbers; addDistributions++)
            {
                distributions.Add(random.NextDouble());
            }
            var sumOfDistributions = distributions.Sum();
            var output = distributions.Select(
                distribution => 
                    (int)Math.Round(distribution / sumOfDistributions * targetTotal, 0)).ToList();
            RoundUpOutput(output, targetTotal);
            return output;
        }
        private void RoundUpOutput(List<int> output, int targetTotal)
        {
            var difference = targetTotal - output.Sum();
            if (difference !=0)
            {
                var indexToAdjust =
                    difference > 0 ? output.IndexOf(output.Min()) : output.IndexOf(output.Max());
                output[indexToAdjust]+= difference;
            }
        }
    }
