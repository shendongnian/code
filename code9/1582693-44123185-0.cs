    [MyAttribute(false, true)]
    public class MyClass
    {
    }
    public class MyAttribute : System.Attribute
    {
        public MyAttribute(bool reviewed, bool hasTestSuit)
        {
            this.Reviewed = reviewed;
            this.HasTestSuit = hasTestSuit;
        }
        bool Reviewed { get; set; }
        bool HasTestSuit { get; set; }
    }
