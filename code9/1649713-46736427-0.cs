    public class WeightedItem<T>
    {
        private T value;
        private int weight;
        private int cumulativeSum;
        private static Random rndInst = new Random();
        public WeightedItem(T value, int weight)
        {
            this.value = value;
            this.weight = weight;
        }
        public static T Choose(List<WeightedItem<T>> items)
        {
            int cumulSum = 0;
            int cnt = items.Count();
            
            for (int slot = 0; slot < cnt; slot++)
            {
                cumulSum += items[slot].weight;
                items[slot].cumulativeSum = cumulSum;
            }
            
            double divSpot = rndInst.NextDouble() * cumulSum;
            WeightedItem<T> chosen =  items.FirstOrDefault(i => i.cumulativeSum >= divSpot);
            if (chosen == null) throw new Exception("No item chosen - there seems to be a problem with the probability distribution.");
            return chosen.value;
        }
    }
