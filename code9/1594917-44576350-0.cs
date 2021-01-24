    class Program
    {
        public K[] ksmall = new K[number];
        static void Main(string[] args)
        {
            VariableHolder.ksmall = new K[0];
        }
    }
    public class K
    {
        //something
    }
    public class A
    {
        public void SomethingElse()
        {
            //do something with ksmall
        }
    }
    public static class VariableHolder
    {
        public static K[] ksmall = new K[number];
    }
