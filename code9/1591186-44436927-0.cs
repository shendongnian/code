    public class CatStuff
    {
        private int cats;
        public CatStuff(int howManyCats)
        {
            this.cats = howManyCats;
        }
    
        public void TestMethod()
        {
            Console.WriteLine("{0} cats", this.cats);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var cats1 = new CatStuff(1000);
            cats1.TestMethod();
    
             var cats2 = new CatStuff(6);
            cats2.TestMethod();
        }
    }
