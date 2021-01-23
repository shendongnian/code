    public class Foo : List<String>
    {
        public void Add(int n)
        {
            base.Add(n.ToString());
        }
        public void Add(DateTime dt, double x)
        {
            base.Add($"{dt.ToShortDateString()} {x}");
        }
    }
