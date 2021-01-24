    public class QueryServiceInstanceProvider : StandardInstanceProvider
    {
        protected override string GetName(System.Reflection.MethodInfo methodInfo, object[] arguments)
        {
            string connection = arguments[0].ToString();
                
            return connection.Split('=')[0];
        }
        protected override Ninject.Parameters.IConstructorArgument[] GetConstructorArguments(System.Reflection.MethodInfo methodInfo, object[] arguments)
        {
            return base.GetConstructorArguments(methodInfo, arguments).Skip(1).ToArray();
        }
    }
