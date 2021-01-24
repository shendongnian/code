    [PSerializable]
    public class LogMethodAttribute : OnMethodBoundaryAspect, IInstanceScopedAspect
    {
        private bool disabled;
        public override void OnEntry( MethodExecutionArgs args )
        {
            if ( !this.disabled )
            {
                Console.WriteLine( "OnEntry: {0}({1})", args.Method.Name, args.Arguments.GetArgument( 0 ) );
            }
        }
        public object CreateInstance( AdviceArgs adviceArgs )
        {
            LogMethodAttribute clone = (LogMethodAttribute) this.MemberwiseClone();
            Type type = adviceArgs.Instance.GetType();
            if ( type.IsGenericType )
            {
                Type[] genericArguments = type.GetGenericArguments();
                // Filter out targets where T is string.
                if ( genericArguments[0] == typeof( string ) )
                {
                    clone.disabled = true;
                }
            }
            return clone;
        }
        public void RuntimeInitializeInstance()
        {
        }
    }
    class Program
    {
        static void Main( string[] args )
        {
            var obj1 = new Class1<int>();
            obj1.Method1(1);
            var obj2 = new Class1<string>();
            obj2.Method1("a");
        }
    }
    
    [LogMethod(AttributeTargetElements = MulticastTargets.Method)]
    public class Class1<T>
    {
        public void Method1(T a)
        {
        }
    }
