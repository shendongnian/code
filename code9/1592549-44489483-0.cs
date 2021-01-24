    public interface ISampleInterface
    {
        string Value1 { get; }
        string Value2 { get; }
    }
    public class Sample : ISampleInterface
    {
        private string _Value1;
        public string Value1
        {
            get { return _Value1; }
            set { _Value1 = value; }
        }
        private string _Value2;
        public string Value2
        {
            get { return _Value2; }
            set { _Value2 = value; }
        }
        public Sample()
        {
        }
        public Sample(ISampleInterface sample)
        {
            //sample.Value1 = 14; not possible
            this.Value1 = sample.Value1;
            this.Value2 = sample.Value2;
        }
    }
