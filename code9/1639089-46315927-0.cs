    public class StackOverflower
    {
        private string m_MyText;
        public string MyText
        {
            get { return MyText; }
            set { this.m_MyText = value; }
        }
    }
    class Program
    {
        [System.STAThread()]
        static void Main(string[] args)
        {
            var foo = new StackOverflower();
            System.Console.WriteLine(foo.MyText);
        }
    }
