        public abstract class DataRetrieverAbstract
        {
            public virtual event Action<float> DataReaded;
            protected void FireDataReaded(float arg)
            {
                DataReaded?.Invoke(arg);
            }
        }
        public class DataRetriever : DataRetrieverAbstract
        {
            public int CollectionInterval { get; set; }
            public float DataResult { get; private set; }
            private float ReadData()
            {
                return 1; //in reality it returns different values every time
            }
            public async Task StartReading(CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(CollectionInterval * 1000);
                    DataResult = ReadData();
                }
                FireDataReaded(DataResult);
            }
        }
