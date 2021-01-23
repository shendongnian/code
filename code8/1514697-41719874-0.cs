    using System;
    using System.Reflection;
    class MyClass
    {
        private int privField;
        public MyClass(int val)
        {
            this.privField = val;
        }
        public void printValueOfPrivate()
        {
            var fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Name: " + fields[0].Name + " Value: " + fields[0].GetValue(this));
        }
    }
    public class HelloWorld
    {
        static public void Main()
        {
            var mc = new MyClass(7);
            mc.printValueOfPrivate();
        }
    }
