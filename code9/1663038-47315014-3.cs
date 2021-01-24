        public class SampleComparer : IEqualityComparer<Sample>
        {
            public bool Equals(Sample x, Sample y)
            {
                return x.property == y.property &&
                    Enumerable.SequenceEqual(x.someListProperty, y.someListProperty);
            }
            public int GetHashCode(Sample obj)
            {
                // Implement
            }
        }
    *(for implementing the `GetHashCode` see: https://stackoverflow.com/q/263400/6400526)*
    and then:
        var result = list.GroupBy(k => k, new SampleComparer());
    tested on the following data and it returns 3 groups:
        List<Sample> a = new List<Sample>()
        {
            new Sample { property = "a", someListProperty = new List<string> {"a"}, someOtherPropery = "1"},
            new Sample { property = "a", someListProperty = new List<string> {"a"}, someOtherPropery = "2"},
            new Sample { property = "a", someListProperty = new List<string> {"b"}, someOtherPropery = "3"},
            new Sample { property = "b", someListProperty = new List<string> {"a"}, someOtherPropery = "4"},
        };
