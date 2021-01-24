    public class Derived : Base
    {
        public override Dictionary<string, int> RunAtOptions { get; }
        public Derived()
        {
            RunAtOptions = new Dictionary<string, int>
            {
                ["Option1"] = 1,
                ["Option2"] = 2
            }
        }
    }
