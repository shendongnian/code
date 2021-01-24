    public class MyClass
    {
        public char Val { get; set; }
    }
    MyClass obj1 = new MyClass() { Val = 'a' };
    MyClass obj2 = obj1;
    obj1.Equals(obj2); // true
