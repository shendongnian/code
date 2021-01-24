    public delegate void TestDelegate();
    public static class ExampleOne
    {
        public static Action<string, bool> OnFunctionCall
            => (message, flag) => Console.WriteLine("OnFunctionCall");
        public static Action<string, bool> OnFunctionCallField 
            = (message, flag) => Console.WriteLine("OnFunctionCallField");
    }
    public static class ExampleTwo
    {
        public static TType CreateDelegate<TType>(Expression<Func<object>> expression)
            where TType : class
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException(nameof(expression));
            }
            var method = new DynamicMethod($"{Guid.NewGuid()}", typeof(void), Type.EmptyTypes, typeof(TType), true);
            ILGenerator il = method.GetILGenerator();
            // Get typed invoke method and
            // call getter or load field
            MethodInfo invoke;
            if (body.Member is PropertyInfo pi)
            {
                invoke = pi.PropertyType.GetMethod("Invoke");
                il.Emit(OpCodes.Call, pi.GetGetMethod());
            }
            else if (body.Member is FieldInfo fi)
            {
                invoke = fi.FieldType.GetMethod("Invoke");
                il.Emit(OpCodes.Ldsfld, fi);
            }
            else
            {
                throw new ArgumentException(nameof(expression));
            }
            il.Emit(OpCodes.Ldstr, method.Name);
            il.Emit(OpCodes.Ldc_I4_0);
            il.Emit(OpCodes.Callvirt, invoke);
            il.Emit(OpCodes.Ret);
            return method.CreateDelegate(typeof(TestDelegate)) as TType;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            ExampleTwo
                .CreateDelegate<TestDelegate>(() => ExampleOne.OnFunctionCall)
                .Invoke();
            ExampleTwo
                .CreateDelegate<TestDelegate>(() => ExampleOne.OnFunctionCallField)
                .Invoke();
            Console.ReadLine();
        }
    }
