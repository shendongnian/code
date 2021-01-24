    public abstract class MyGenericClass<T>
    {
        public abstract Type type { get; set; }
    }
    public class MyGenericClass<T, T2> : MyGenericClass<T>
    {
        public Expression<Func<T, T2>> expression { get; set; }
        public MyGenericClass(Expression<Func<T, T2>> expression)
        {
            type = typeof(T2);  // I save the type of T2
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
            foreach (MyGenericClass<T> myGenericItem in class1.MyGenericList)
            {
                MethodInfo method = GetType().GetMethod("MethodWithArgument");
                MethodInfo generic = method.MakeGenericMethod(new Type[] { myGenericItem.type });
                string g = (string)generic.Invoke(this, new object[] { myGenericItem });
            }
        }
        // I introduce T2 in this method
        public string MethodWithArgument<T2>(MyGenericClass<T> myClass)
        {
            // Now, the casting is valid
            MyGenericClass<T, T2> mySubClass = (MyGenericClass<T, T2>)myClass;
            var a = mySubClass.expression;
            // I can work with expression here
        }
    }
