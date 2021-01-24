    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string> {
                "Surname1, Name1;Address1;State1;YES;Group1",
                "Surname2, Name2;Address2;State2;YES;Group2",
                "Surname2, Name2;Address2;State2;YES;Group1",
                "Surname3, Name3;Address3;State3;NO;Group1",
                "Surname1, Name1;Address2;State1;YES;Group1",
        };
            var transformed = input.Select(s => s.Split(';'))
                .GroupBy(   s => new string[] { s[0], s[1], s[2], s[3] }, 
                            (key, elements) => string.Join(";", key) + ";" + string.Join(" ", elements.Select(e => e.Last())), 
                new MyEqualityComparer())
                .ToList();
        }
    }
    internal class MyEqualityComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y)
        {
            return x[0] == y[0] && x[1] == y[1] && x[2] == y[2];
        }
        public int GetHashCode(string[] obj)
        {
            int hashCode = obj[0].GetHashCode();
            hashCode = hashCode ^ obj[1].GetHashCode();
            hashCode = hashCode ^ obj[2].GetHashCode();
            return hashCode;
        }
    }
