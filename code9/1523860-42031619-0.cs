        public void Run()
        {
            List<dynamic> listOfMyClasses = new List<dynamic>();
            dynamic myClass = new MyClass<int>();
            listOfMyClasses.Add(myClass);
        }
        public class MyClass<T>
        {
            public void DoSomething() { }
        }
