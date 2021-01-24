    public class CustomStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
            {
                return false;
            }
            else
            {
                var x_split = x.Split('/');
                var y_split = y.Split('/');
                return x_split[0] == y_split[0];
            }
        }
        public int GetHashCode(string str)
        {
            return 1;
        }
    }
    var result = list1.Except(list2, new CustomStringComparer());
