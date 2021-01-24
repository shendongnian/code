    public class BucketsWithRandomValues
    {
        private Random random = new Random();
    
        public void FillWithValuesInEachBucket(IList<KeyValuePair<int, int>> list, int bucketSize = 4, int valueToPut = 1)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
    
            int i = 0;
            while (i + bucketSize <= list.Count)
            {
                var index = random.Next(i, i + bucketSize); // exclusive upper bound
                list[index] = new KeyValuePair<int, int>(list[index].Key, valueToPut);
                i += bucketSize;
            }
        }
    }
