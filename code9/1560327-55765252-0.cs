    public class Int32List : List<int>
    {
        public Int32List(string arr) : base(arr.Split(',').Select(a => int.Parse(a.Trim())))
        {
        }
    }
