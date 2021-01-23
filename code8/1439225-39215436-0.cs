    public class ClassWithMutable
    {
        public IImumutable Mutable { get { return _mutable; } }
        private Mutable _mutable;
        public ClassWithMutable()
        {
            _mutable = new Mutable()
            {
                Value = 1
            };
        }
    }
    public interface IImumutable
    {
        int Value { get; }
    }
    public class Mutable : IImumutable
    {
        public int Value { get; set; }
    }
