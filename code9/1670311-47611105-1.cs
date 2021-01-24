    public class Form1:Form
    {
        public Form1()
        {
            InitializeComponents();
            MyClass c = new MyClass();
            c.ChangeBackgroundColor(this);
        }
    }
