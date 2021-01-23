    public class RandomMeasurementSource : IMeasurementSource
    {
        private readonly Random random = new Random();
        private readonly int min;
        private readonly int max;
        public RandomMeasurementSource(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
        public MeasureModel GetNext()
        {
            return new MeasureModel { DateTime = DateTime.Now, Value = random.Next(min, max) };
        }
    }
