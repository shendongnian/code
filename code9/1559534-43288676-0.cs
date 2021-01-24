    class A
    {
        public string Text { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A { Text = "Text" };
            a.Tag("object A tag");
            string tag = a.Tag(), text = a.Text;
        }
    }
