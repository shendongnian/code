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
            foreach(ISmth item in (List<object>)myObj) {
                Console.Write(item.MyProperty);
            }
        }
    List<Student> stdList = new List<Student>();
    DoSmth(stdList.Cast<object>().ToList());
