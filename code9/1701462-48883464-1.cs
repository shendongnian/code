        class Program
        {
            static void Main(string[] args)
            {
                var x = new Dictionary<SomeClass, List<AnotherClass>>();
                var y = new Dictionary<SomeClass, List<AnotherClass>>();
    
                x.Add(new SomeClass { SomeNumericProperty = 1 }, new List<AnotherClass> { new AnotherClass { SomeStringProperty = "1" } });
                y.Add(new SomeClass { SomeNumericProperty = 1 }, new List<AnotherClass> { new AnotherClass { SomeStringProperty = "1" } });
    
                var w = new MyCustomComparer();
                var z = w.Equals(x, y);
            }
        }
    
        public class MyCustomComparer : IEqualityComparer<Dictionary<SomeClass, List<AnotherClass>>>
        {
            public bool Equals(Dictionary<SomeClass, List<AnotherClass>> x, Dictionary<SomeClass, List<AnotherClass>> y)
            {
                var keysAreEqual = x.Keys.OrderBy(o => o.GetHashCode()).SequenceEqual(y.Keys.OrderBy(o => o.GetHashCode()));
                var valuesAreEqual = x.SelectMany(o => o.Value).OrderBy(o => o.GetHashCode()).SequenceEqual(y.SelectMany(o => o.Value).OrderBy(o => o.GetHashCode()));
    
                return keysAreEqual && valuesAreEqual;
            }
    
            public int GetHashCode(Dictionary<SomeClass, List<AnotherClass>> obj)
            {
                throw new NotImplementedException();
            }
        }
    
        public class AnotherClass
        {
            protected bool Equals(AnotherClass other)
            {
                return string.Equals(SomeStringProperty, other.SomeStringProperty);
            }
    
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
    
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
    
                if (obj.GetType() != this.GetType())
                {
                    return false;
                }
    
                return Equals((AnotherClass)obj);
            }
    
            public override int GetHashCode()
            {
                int hash = 13;
                hash = (hash * 7) + SomeStringProperty.GetHashCode();
                return hash;
            }
    
            public string SomeStringProperty { get; set; }
        }
    
        public class SomeClass
        {
            public int SomeNumericProperty { get; set; }
    
            protected bool Equals(SomeClass other)
            {
                return SomeNumericProperty == other.SomeNumericProperty;
            }
    
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
    
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
    
                if (obj.GetType() != this.GetType())
                {
                    return false;
                }
    
                return Equals((SomeClass)obj);
            }
    
            public override int GetHashCode()
            {
                int hash = 13;
                hash = (hash * 7) + SomeNumericProperty.GetHashCode();
                return hash;
            }
        }
