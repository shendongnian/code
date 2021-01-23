        public class MyClass
        {
            public delegate void callableMethod();
            callableMethod outsideMethod;
            
            public MyClass(callableMethod usersMethod)
            {
                outsideMethod = usersMethod;
            }
        }
