    static void Main(string[] args)
            {
                 Type MsgType = typeof(ThirdParty).GetNestedType(
                    "MsgType", BindingFlags.Instance | BindingFlags.NonPublic);
            object msg = Activator.CreateInstance(MsgType);
            MethodInfo CallEvent = typeof(AnotherThirdParty).GetMethod("CallEvent");
            CallEvent = CallEvent.MakeGenericMethod(MsgType);
            MethodInfo AnotherFunc = typeof(ThirdParty).GetMethod(
                "AnotherFunc", BindingFlags.Static | BindingFlags.NonPublic);
            var actionType = typeof(Action<>).MakeGenericType(MsgType);
            var actionDelegate = AnotherFunc.CreateDelegate(actionType);
            var param = Expression.Parameter(typeof(int));
            var funcDelegate = Expression.Lambda(Expression.Constant(actionDelegate),param).Compile();
            CallEvent.Invoke(null, new []{ funcDelegate, msg });
            Console.ReadLine();
            }
    
            public class ThirdParty
            {
                private struct MsgType
                { }
    
                private static void AnotherFunc(MsgType msg)
                {
                    Console.WriteLine("A");
                }
            }
    
            public class AnotherThirdParty
            {
                public static void CallEvent<T>(Func<int, Action<T>> action, T arg)
                {
                    action(1)(arg);
                }
            }
