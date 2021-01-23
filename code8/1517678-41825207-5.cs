    public class BouncingMeasurementSource : IMeasurementSource
    {
        private readonly double max;
        private double step;
        private double current;
        public BouncingMeasurementSource(int max, double step)
        {
            this.max = max;
            this.step = step;
            this.current = max;
        }
        public MeasureModel GetNext()
        {
            var model = new MeasureModel { DateTime = DateTime.Now, Value = current };
            current -= step;
            if (current < 0 || max < current)
            {
                step = -step;
                current = current < 0 ? 0 : max;
            }
            return model;
        }
    }
