    public abstract class Base
    {
        protected int Property1;
        protected int Property2;
    
        protected void Setup(View view)
        {
            view.Property1 = Property1.ToString();
            view.Property2 = Property2.ToString();
        }
    }
    
    public class Derived1 : Base
    {
        int Property3;
    
        public View GetView()
        {
            View1 view = new View1();
            view.Property3 = Property3.ToString();
            Setup(view);
            return view;
        }
    }
    
    public class Derived2 : Base
    {
        int Property4;
    
        public View GetView()
        {
            View2 view = new View2();
            view.Property4 = Property4.ToString();
            Setup(view);
            return view;
        }
    }
