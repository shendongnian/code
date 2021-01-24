    public class MyClass
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Family{ set; get; }
        public override String ToString()
        {
            return $"Id:{Id},Name:{Name}";
        }
    }
