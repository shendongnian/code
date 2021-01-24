    public class CustomStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            // Ensure that neither string is null
            if (!object.ReferenceEquals(x, null) && !object.ReferenceEquals(y, null))
            {
                var x_split = x.Split('/');
                var y_split = y.Split('/');
                // Compare only first element of split strings
                return x_split[0] == y_split[0];
            }
            return false;
        }
        public int GetHashCode(string str)
        {
            // Ensure string is not null
            if (!object.ReferenceEquals(str, null))
            {
                // Return hash code of first element in split string
                return str.Split('/')[0].GetHashCode();
            }
            // Return 0 if null
            return 0;
        }
    }
    var result = list1.Except(list2, new CustomStringComparer());
