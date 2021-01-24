    public class Foo : IEquatable<Foo>
    {
        public int FooValue { get; set; }
        public List<Bar> Bars { get; set; }
        public bool Equals(Foo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (FooValue != other.FooValue) return false;
            if (Bars == null ^ other.Bars == null) return false;
            return Bars == null || Bars.SequenceEqual(other.Bars);
        }
    }
    public class Bar : IEquatable<Bar>
    {
        public int BarValue { get; set; }
        public List<FooBar> FooBars { get; set; }
        public bool Equals(Bar other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if( BarValue != other.BarValue) return false;
            if (FooBars == null ^ other.FooBars == null) return false;
            return FooBars==null || FooBars.SequenceEqual(other.FooBars);
        }
    }
    public class FooBar : IEquatable<FooBar>
    {
        public int FooBarValue { get;  set; }
        public bool Equals(FooBar other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FooBarValue == other.FooBarValue;
        }
    }
