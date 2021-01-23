    public abstract class Base<T>
        where T : View
    {
        protected int Property1;
        protected int Property2;
        public abstract T GetView();
    }
    public class Derived1 : Base<View1>
    {
        int Property3;
        public override View1 GetView()
        {
            View1 view = new View1();
            view.Property3 = Property3.ToString();
            return view;
        }
    }
