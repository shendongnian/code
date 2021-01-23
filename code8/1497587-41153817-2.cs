    public interface IListener
    {
        void Update(int value);
    }
    public class MainClass : IListener
    {
        private SecondaryClass secondaryClass;
        private int testValue;
        public MainClass()
        {
            this.secondaryClass = new SecondaryClass(this);
            testValue = 0;
        }
        public void Update(int val)
        {
            testValue = val;
        }
    }
    public class SecondaryClass : Form
    {
        private IListener Listener { get; }
        public SecondaryClass(IListener listener) 
        {
            this.Listener = listener;
        }
        private void button1_click(Object sender, EventArgs e)
        {
            this.Listener.Update(100);
        }
    }
