    public abstract class MyGenericClass<T>
    {
        public abstract string DoTheWork();
    }
        
    public class MyGenericClass<T, T2> : MyGenericClass<T>
    {
        public override string DoTheWork()
        {
            // I can use expression here
        }
    
        private Expression<Func<T, T2>> expression { get; set; }
    
        public MyGenericClass(Expression<Func<T, T2>> expression)
        {
            this.expression = expression;
        }
    }
    
    public class MyClass<T>
    {
        public List<MyGenericClass<T>> MyGenericList = new List<MyGenericClass<T>>();
        public void ReceivingMethod<T2>(Expression<Func<T, T2>> expression)
        {
            MyGenericClass<T, T2> genericImp = new MyGenericClass<T, T2>(expression);
        }
    }
    
    public class Client<T>
    {
        MyClass<T> class1;
        public void Do()
        {
            // I don't need to cast to MyGenericClass<T, T2>
            foreach (MyGenericClass<T> myGenericItem in class1.MyGenericList)
            {
                    string result = myGenericItem.DoTheWork();
            }
        }
    }
