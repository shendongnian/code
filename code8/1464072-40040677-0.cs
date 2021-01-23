    public class ClassType
    {
        public string a { get; set; }
        public int b { get; set; }
    }
    public class Class1
    {
        public ClassType[] classType;
    }
    public class Wrapper
    {
        public Class1 WrappedClass1;
    }
    public class Class2
    {
        public Wrapper Wrapped;
        public Class2(Wrapper wrapper)
        {
            Wrapped = wrapper;
        }
        public void ChangeClass1()
        {
            WrappedClass1.WrappedClass1 = new Class1();
        }
    }
    Class1 class1 = new Class1();
    Wrapper wrapper = new Wrapper();
    wrapper.WrappedClass1 = class1;
    Class2 class2 = new Class2(wrapper);
    class2.ChangeClass1();
    MessageBox.Show(wrapper.WrappedClass1 == class2.Wrapped.WrappedClass1); // <--- true
    
