    public interface ISmth {
            int MyProperty { get; set; }
        }
        public class Student : ISmth {
            public int MyProperty { get;  set; }
        }
        public class Employee : ISmth {
            public int MyProperty { get; set; }
        }
    public static void DoSmth(object myObj) {
            foreach(var item in (List<ISmth>)myObj) {
                Console.Write(item.MyProperty);
            }
        }
