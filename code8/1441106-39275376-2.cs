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
    var f = new Foo { 0, 1, 2, "Zanzibar", { DateTime.Now, 3.7 } };
