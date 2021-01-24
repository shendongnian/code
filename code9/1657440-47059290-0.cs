    public class MyList<T> : List<T>
    {
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("(");
            foreach (var element in this)
            {
                s.Append(element.ToString() + ",");
            }
            s.Replace(",", ")", s.Length - 1, 1);
            return s.ToString();
        }
    }
