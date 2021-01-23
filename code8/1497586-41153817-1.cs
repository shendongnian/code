    public class MainClass
    {
        private SecondaryClass secondaryClass;
        private int testValue;
        public MainClass()
        {
            this.secondaryClass = new SecondaryClass(this.UpdateTestValue);
            testValue = 0;
        }
        public void UpdateTestValue (int val)
        {
            testValue = val;
        }
    }
    public class SecondaryClass : Form
    {
        private Action<int> UpdateValue { get; }
        public SecondaryClass(Action<int> updateValue) 
        {
            this.UpdateValue = updateValue;
        }
        private void button1_click(Object sender, EventArgs e)
        {
            this.UpdateTestValue(100);
        }
    }
