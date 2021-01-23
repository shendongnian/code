        public static void Main(string[] args)
        {
            //so your LoadFromDll method should return Type. Type doesn't have generic implementation !
            Type type = typeof(SubClass1);
            BaseClassUtil.CallFoo<BaseClass>(type);
            Type type2 = typeof(SubClass2);
            //you can write BaseClassUtil.CallFoo<SubClass2>(type2); if you want
            BaseClassUtil.CallFoo<BaseClass>(type2);
        }
        public class BaseClassUtil
        {
            public static void CallFoo<T>(Type type) where T : BaseClass
            {
                T instance = (T)Activator.CreateInstance(type);
                instance.Foo();
            }
        }
        public class TestClass
        {
            public int ID { get; set; }
        }
        public abstract class BaseClass
        {
            public abstract void Foo();
        }
        public class SubClass1 : BaseClass
        {
            public override void Foo()
            {
                Console.WriteLine("SubClass 1");
            }
        }
        public class SubClass2 : BaseClass
        {
            public override void Foo()
            {
                Console.WriteLine("SubClass 2");
            }
        }
