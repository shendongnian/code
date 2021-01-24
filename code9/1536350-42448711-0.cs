    class Program
        {
            static void Main(string[] args)
            {
                var bc = new BaseClass(3);
                var dc = new DerivedClass(5);
    
                Console.WriteLine("Base Class Method A: " + bc.MethodA());
                Console.WriteLine("Derived Class Method A: " + dc.MethodA());
                Console.WriteLine("Base Class Method B: " + bc.MethodB());
                Console.WriteLine("Derived Class Method B: " + dc.MethodB());
                Console.ReadLine();
            }
        }
    
        public class BaseClass {
            protected int _classId;
    
            public BaseClass(int classId) {
                _classId = classId;
            }
    
            public virtual string MethodA() {
                return "Method A in base class: " + _classId.ToString();
            }
    
            public string MethodB()
            {
                return "I am a method B in the base class: " + _classId.ToString();
            }
        }
    
        public class DerivedClass : BaseClass {
            public DerivedClass(int classId)
                : base(classId)
            {
    
            }
    
            public override string MethodA() {
                return "Method A in derived class: " + _classId.ToString();
            }
        }
