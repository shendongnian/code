    public class MaxLengthEventArgs : EventArgs
    {
        public MaxLengthEventArgs(string value)
        {
            LastAppended = value;
        }
        public string LastAppended { get; private set; }
    }
    public delegate void MaxLengthEventHandler(object sender, MaxLengthEventArgs args);
    public class StringAccumulator
    {
        protected StringBuilder Builder { get; private set; }
        public StringAccumulator(int maxLength)
        {
            if (maxLength < 0)
            {
                throw new ArgumentOutOfRangeException("maxLength", "must be positive");
            }
            Builder = new StringBuilder();
            MaxLength = maxLength;
        }
        public StringAccumulator Append(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var sofar = value.Length + Builder.Length;
                if (sofar <= MaxLength)
                {
                    Builder.Append(value);
                    if ((OnMaxLength != null) && (sofar == MaxLength))
                    {
                        OnMaxLength(this, new MaxLengthEventArgs(value));
                    }
                }
                else
                {
                    throw new InvalidOperationException("overflow");
                }
            }
            return this;
        }
        public override string ToString()
        {
            return Builder.ToString();
        }
        public int MaxLength { get; private set; }
        public event MaxLengthEventHandler OnMaxLength;
    }
    class Program
    {
        static void Test(object sender, MaxLengthEventArgs args)
        {
            var acc = (StringAccumulator)sender;
            Console.WriteLine(@"max length ({0}) reached with ""{1}"" : ""{2}""", acc.MaxLength, args.LastAppended, acc.ToString());
        }
        public static void Main(string[] args)
        {
            var acc = new StringAccumulator(10);
            try
            {
                acc.OnMaxLength += Test;
                acc.Append("abc");
                acc.Append("def");
                acc.Append("ghij");
                Console.WriteLine();
                acc.Append("ouch...");
                Console.WriteLine("(I won't show)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
