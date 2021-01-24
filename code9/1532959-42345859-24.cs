    public class Class1
    {        
        public delegate void Counter(int c); // this delegate allows you to transmit an integer
        public event Counter CountEvent;
        public Class1()
        {
        }
