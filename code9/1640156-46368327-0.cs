    public interface IChart
    {
        ISeries GetSeries();
    }
    public abtract class Chart : IChart
    {
        public virtual ISeries GetSeries()
        {
            throw new NotImplementedException();
        }
    }
    public class AnalogChart : Chart, IChart
    {
        public new ITimeSeries<float> GetSeries()
        {
            return new Series<float>();
        }
        ISeries IChart.GetSeries()
        {
            return GetSeries();
        }
    }
    public class PhasorChart : Chart, IChart
    {
        public new IPhasorSeries GetSeries()
        {
            return new PhasorSeries();
        }
        ISeries IChart.GetSeries()
        {
            return GetSeries();
        }
    }
